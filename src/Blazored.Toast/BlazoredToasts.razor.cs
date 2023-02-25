using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
    [Parameter] public bool DisableTimeout { get; set; }
    [Parameter] public bool PauseProgressOnHover { get; set; } = false;
    [Parameter] public int ExtendedTimeout { get; set; }

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

        if (IconType == IconType.Custom
            && string.IsNullOrWhiteSpace(InfoIcon)
            && string.IsNullOrWhiteSpace(SuccessIcon)
            && string.IsNullOrWhiteSpace(WarningIcon)
            && string.IsNullOrWhiteSpace(ErrorIcon))
        {
            throw new ArgumentException("IconType is Custom but icon parameters are not set.");
        }
    }

    private ToastSettings BuildCustomToastSettings(Action<ToastSettings>? settings)
    {
        var instanceToastSettings = new ToastSettings();
        settings?.Invoke(instanceToastSettings);
        instanceToastSettings.Timeout = instanceToastSettings.Timeout == 0 ? Timeout : instanceToastSettings.Timeout;
        instanceToastSettings.DisableTimeout ??= DisableTimeout;
        instanceToastSettings.PauseProgressOnHover ??= PauseProgressOnHover;
        instanceToastSettings.ExtendedTimeout ??= ExtendedTimeout;
        instanceToastSettings.Position ??= Position;

        return instanceToastSettings;
    }

    private ToastSettings BuildToastSettings(ToastLevel level, RenderFragment message, Action<ToastSettings>? settings)
    {
        var toastInstanceSettings = new ToastSettings();
        settings?.Invoke(toastInstanceSettings);

        return level switch
        {
            ToastLevel.Error => new ToastSettings(
                $"blazored-toast-error {toastInstanceSettings.AdditionalClasses}",
                toastInstanceSettings.IconType ?? IconType,
                toastInstanceSettings.Icon ?? ErrorIcon ?? "",
                ShowProgressBar,
                ShowCloseButton,
                toastInstanceSettings.OnClick,
                toastInstanceSettings.Timeout == 0 ? Timeout : toastInstanceSettings.Timeout,
                toastInstanceSettings.DisableTimeout ?? DisableTimeout,
                toastInstanceSettings.PauseProgressOnHover ?? PauseProgressOnHover,
                toastInstanceSettings.ExtendedTimeout ?? ExtendedTimeout,
                toastInstanceSettings.Position ?? Position),
            ToastLevel.Info => new ToastSettings(
                $"blazored-toast-info {toastInstanceSettings.AdditionalClasses}",
                toastInstanceSettings.IconType ?? IconType,
                toastInstanceSettings.Icon ?? InfoIcon ?? "",
                ShowProgressBar,
                ShowCloseButton,
                toastInstanceSettings.OnClick,
                toastInstanceSettings.Timeout == 0 ? Timeout : toastInstanceSettings.Timeout,
                toastInstanceSettings.DisableTimeout ?? DisableTimeout,
                toastInstanceSettings.PauseProgressOnHover ?? PauseProgressOnHover,
                toastInstanceSettings.ExtendedTimeout ?? ExtendedTimeout,
                toastInstanceSettings.Position ?? Position),
            ToastLevel.Success => new ToastSettings(
                $"blazored-toast-success {toastInstanceSettings.AdditionalClasses}",
                toastInstanceSettings.IconType ?? IconType,
                toastInstanceSettings.Icon ?? SuccessIcon ?? "",
                ShowProgressBar,
                ShowCloseButton,
                toastInstanceSettings.OnClick,
                toastInstanceSettings.Timeout == 0 ? Timeout : toastInstanceSettings.Timeout,
                toastInstanceSettings.DisableTimeout ?? DisableTimeout,
                toastInstanceSettings.PauseProgressOnHover ?? PauseProgressOnHover,
                toastInstanceSettings.ExtendedTimeout ?? ExtendedTimeout,
                toastInstanceSettings.Position ?? Position),
            ToastLevel.Warning => new ToastSettings(
                $"blazored-toast-warning {toastInstanceSettings.AdditionalClasses}",
                toastInstanceSettings.IconType ?? IconType,
                toastInstanceSettings.Icon ?? WarningIcon ?? "",
                ShowProgressBar,
                ShowCloseButton,
                toastInstanceSettings.OnClick,
                toastInstanceSettings.Timeout == 0 ? Timeout : toastInstanceSettings.Timeout,
                toastInstanceSettings.DisableTimeout ?? DisableTimeout,
                toastInstanceSettings.PauseProgressOnHover ?? PauseProgressOnHover,
                toastInstanceSettings.ExtendedTimeout ?? ExtendedTimeout,
                toastInstanceSettings.Position ?? Position),
            _ => throw new InvalidOperationException()
        };
    }

    private ToastInstance ShowToast(ToastLevel level, RenderFragment message, Action<ToastSettings>? toastSettings)
    {
        var settings = BuildToastSettings(level, message, toastSettings);
        var toast = new ToastInstance(message, level, settings, RemoveToast);
        AddToastToList(toast);
        
        return toast;
    }

    private ToastInstance ShowCustomToast(Type contentComponent, ToastParameters? parameters, Action<ToastSettings>? settings)
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
        var toastInstance = new ToastInstance(childContent, toastSettings, RemoveToast);
        AddToastToList(toastInstance);

        return toastInstance;
    }

    //todo remove comment after review
    //same code was called multiple times, added this method instead
    private void AddToastToList(ToastInstance instance)
    {
        InvokeAsync(() =>
        {
            if (ToastList.Count < MaxToastCount)
            {
                ToastList.Add(instance);
                StateHasChanged();
            }
            else
            {
                ToastWaitingQueue.Enqueue(instance);
            }
        });
    }

    private void ShowEnqueuedToast()
    {
        InvokeAsync(() =>
        {
            bool _stateHasChanged = false;
            //todo remove comment after review
            //check before we dequeue, and show all queued toasts until MaxToastCount, if for example somone cleared all LevelToast.Error 
            //and there was more than 1 Error toast, we need to show more than 1 new toast from que
            while (ToastList.Count < MaxToastCount && ToastWaitingQueue.Any())
            {
                var toast = ToastWaitingQueue.Dequeue();
                ToastList.Add(toast);
                _stateHasChanged = true;
            }

            if (_stateHasChanged)
            {
                StateHasChanged();
            }
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
                toastInstance.Dispose();
                StateHasChanged();
            }

            var toastInstanceQueued = ToastWaitingQueue.SingleOrDefault(x => x.Id == toastId);
            if(toastInstanceQueued is not null)
            {
                //todo remove comment after review
                //had to recreate new Queue if somone removes toast that was in que list
                ToastWaitingQueue = new Queue<ToastInstance>(ToastWaitingQueue.Where( x=> x.Id != toastId));
                toastInstanceQueued.Dispose();
            }

            ShowEnqueuedToast();

        });
    }

    private void ClearToasts(object? sender, LocationChangedEventArgs args)
    {
        InvokeAsync(() =>
        {
            ToastList.Clear();
            StateHasChanged();

            ShowEnqueuedToast();
        });
    }

    private void ClearAll()
    {
        InvokeAsync(() =>
        {
            ToastList.Clear();
            StateHasChanged();

            ShowEnqueuedToast();
        });
    }

    private void ClearToasts(ToastLevel toastLevel)
    {
        InvokeAsync(() =>
        {
            ToastList.RemoveAll(x => x.CustomComponent is null && x.Level == toastLevel);
            StateHasChanged();

            ShowEnqueuedToast();
        });
    }

    private void ClearCustomToasts()
    {
        InvokeAsync(() =>
        {
            ToastList.RemoveAll(x => x.CustomComponent is not null);
            StateHasChanged();

            ShowEnqueuedToast();
        });
    }

    private void ClearQueue()
    {
        InvokeAsync(() =>
        {
            ToastWaitingQueue.Clear();
            //todo remove comment after review
            //do we need to call StateHasChanged here, nothing on UI did change
            StateHasChanged();
        });
    }

    private void ClearQueueToasts(ToastLevel toastLevel)
    {
        InvokeAsync(() =>
        {
            ToastWaitingQueue = new(ToastWaitingQueue.Where(x => x.Level != toastLevel));
            //todo remove comment after review
            //do we need to call StateHasChanged here, nothing on UI did change
            StateHasChanged();
        });
    }
}
