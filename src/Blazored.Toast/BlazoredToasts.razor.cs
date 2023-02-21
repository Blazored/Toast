using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Blazored.Toast;

public partial class BlazoredToasts
{
    [Inject] private IToastService ToastService { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;
    [Parameter] public IconType IconType { get; set; } = IconType.Blazored;    
    [Parameter] public string? InfoClass { get; set; }
    [Parameter] public string? InfoIcon { get; set; }
    [Parameter] public string? SuccessClass { get; set; }
    [Parameter] public string? SuccessIcon { get; set; }
    [Parameter] public string? WarningClass { get; set; }
    [Parameter] public string? WarningIcon { get; set; }
    [Parameter] public string? ErrorClass { get; set; }
    [Parameter] public string? ErrorIcon { get; set; }
    [Parameter] public ToastPosition Position { get; set; } = ToastPosition.TopRight;
    [Parameter] public int Timeout { get; set; } = 5;
    [Parameter] public int MaxToastCount { get; set; } = int.MaxValue;
    [Parameter] public bool RemoveToastsOnNavigation { get; set; }
    [Parameter] public bool ShowProgressBar { get; set; }
    [Parameter] public RenderFragment? CloseButtonContent { get; set; }
    [Parameter] public bool ShowCloseButton { get; set; } = true;

    private string PositionClass { get; set; } = string.Empty;
    private List<ToastInstance> ToastList { get; set; } = new();
    private Queue<ToastInstance> ToastWaitingQueue { get; set; } = new();

    protected override void OnInitialized()
    {
        ToastService.OnShow += ShowToast;
        ToastService.OnShowComponent += ShowCustomToast;
        ToastService.OnClearAll += ClearAll;
        ToastService.OnClearToasts += ClearToasts;
        ToastService.OnClearCustomToasts += ClearCustomToasts;
        ToastService.OnClearQueue += ClearQueue;
        ToastService.OnClearQueueToasts += ClearQueueToasts;

        if (RemoveToastsOnNavigation)
        {
            NavigationManager.LocationChanged += ClearToasts;
        }

        PositionClass = $"position-{Position.ToString().ToLower()}";

        if (IconType == IconType.Custom
            && string.IsNullOrWhiteSpace(InfoIcon)
            && string.IsNullOrWhiteSpace(SuccessIcon)
            && string.IsNullOrWhiteSpace(WarningIcon)
            && string.IsNullOrWhiteSpace(ErrorIcon))
        {
            throw new ArgumentException("IconType is a Custom, icon parameters must be set.");
        }
    }
    
    private ToastSettings BuildCustomToastSettings(Action<ToastSettings>? settings)
    {
        var instanceToastSettings = new ToastSettings();
        settings?.Invoke(instanceToastSettings);

        return instanceToastSettings;
    }

    private ToastSettings BuildToastSettings(ToastLevel level, RenderFragment message, Action<ToastSettings>? settings)
    {
        var toastInstanceSettings = new ToastSettings();
        settings?.Invoke(toastInstanceSettings);
        
        return level switch
        {
            ToastLevel.Error => new ToastSettings(
                "blazored-toast-error", 
                toastInstanceSettings.IconType ?? IconType, 
                toastInstanceSettings.Icon ?? ErrorIcon ?? "", 
                ShowProgressBar,
                ShowCloseButton,
                toastInstanceSettings.OnClick,
                toastInstanceSettings.Timeout == 0 ? Timeout : toastInstanceSettings.Timeout,
                toastInstanceSettings.PauseProgressOnHover,
                toastInstanceSettings.ExtendedTimeout),
            ToastLevel.Info => new ToastSettings(
                "blazored-toast-info", 
                toastInstanceSettings.IconType ?? IconType, 
                toastInstanceSettings.Icon ?? InfoIcon ?? "", 
                ShowProgressBar,
                ShowCloseButton,
                toastInstanceSettings.OnClick,
                toastInstanceSettings.Timeout == 0 ? Timeout : toastInstanceSettings.Timeout,
                toastInstanceSettings.PauseProgressOnHover,
                toastInstanceSettings.ExtendedTimeout),
            ToastLevel.Success => new ToastSettings(
                "blazored-toast-success", 
                toastInstanceSettings.IconType ?? IconType, 
                toastInstanceSettings.Icon ?? SuccessIcon ?? "", 
                ShowProgressBar,
                ShowCloseButton,
                toastInstanceSettings.OnClick,
                toastInstanceSettings.Timeout == 0 ? Timeout : toastInstanceSettings.Timeout,
                toastInstanceSettings.PauseProgressOnHover, 
                toastInstanceSettings.ExtendedTimeout),
            ToastLevel.Warning => new ToastSettings(
                "blazored-toast-warning", 
                toastInstanceSettings.IconType ?? IconType, 
                toastInstanceSettings.Icon ?? WarningIcon ?? "", 
                ShowProgressBar,
                ShowCloseButton,
                toastInstanceSettings.OnClick,
                toastInstanceSettings.Timeout == 0 ? Timeout : toastInstanceSettings.Timeout,
                toastInstanceSettings.PauseProgressOnHover, 
                toastInstanceSettings.ExtendedTimeout),
            _ => throw new InvalidOperationException()
        };
    }

    private void ShowToast(ToastLevel level, RenderFragment message, Action<ToastSettings>? toastSettings)
    {
        InvokeAsync(() =>
        {
            var settings = BuildToastSettings(level, message, toastSettings);
            var toast = new ToastInstance(message, level, settings);

            if (ToastList.Count < MaxToastCount)
            {
                ToastList.Add(toast);
                
                StateHasChanged();
            }
            else
            {
                ToastWaitingQueue.Enqueue(toast);
            }
        });
    }

    private void ShowCustomToast(Type contentComponent, ToastParameters? parameters, Action<ToastSettings>? settings)
    {
        InvokeAsync(() =>
        {
            var childContent = new RenderFragment(builder =>
            {
                var i = 0;
                builder.OpenComponent(i++, contentComponent);
                if (parameters is not null)
                {
                    foreach (var parameter in parameters.Parameters)
                    {
                        builder.AddAttribute(i++, parameter.Key, parameter.Value);
                    }
                }

                builder.CloseComponent();
            });

            var toastSettings = BuildCustomToastSettings(settings);
            var toastInstance = new ToastInstance(childContent, toastSettings);

            ToastList.Add(toastInstance);

            StateHasChanged();
        });
    }
    
    private void ShowEnqueuedToast()
    {
        InvokeAsync(() =>
        {
            var toast = ToastWaitingQueue.Dequeue();

            ToastList.Add(toast);

            StateHasChanged();
        });
    }

    public void RemoveToast(Guid toastId)
    {
        InvokeAsync(() =>
        {
            var toastInstance = ToastList.SingleOrDefault(x => x.Id == toastId);

            if (toastInstance is not null)
            {
                ToastList.Remove(toastInstance);
                StateHasChanged();
            }

            if (ToastWaitingQueue.Any())
            {
                ShowEnqueuedToast();
            }
        });
    }

    private void ClearToasts(object? sender, LocationChangedEventArgs args)
    {
        InvokeAsync(() =>
        {
            ToastList.Clear();
            StateHasChanged();

            if (ToastWaitingQueue.Any())
            {
                ShowEnqueuedToast();
            }
        });
    }

    private void ClearAll()
    {
        InvokeAsync(() =>
        {
            ToastList.Clear();
            StateHasChanged();
        });
    }

    private void ClearToasts(ToastLevel toastLevel)
    {
        InvokeAsync(() =>
        {
            ToastList.RemoveAll(x => x.CustomComponent is null && x.Level == toastLevel);
            StateHasChanged();
        });
    }

    private void ClearCustomToasts()
    {
        InvokeAsync(() =>
        {
            ToastList.RemoveAll(x => x.CustomComponent is not null);
            StateHasChanged();
        });
    }

    private void ClearQueue()
    {
        InvokeAsync(() =>
        {
            ToastWaitingQueue.Clear();
            StateHasChanged();
        });
    }

    private void ClearQueueToasts(ToastLevel toastLevel)
    {
        InvokeAsync(() =>
        {
            ToastWaitingQueue = new(ToastWaitingQueue.Where(x => x.Level != toastLevel));
            StateHasChanged();
        });
    }
}
