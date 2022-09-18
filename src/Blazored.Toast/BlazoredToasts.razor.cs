﻿using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Blazored.Toast;

public enum IconType { FontAwesome, Material };

public partial class BlazoredToasts
{
    [Inject]
    private IToastService ToastService { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Parameter]
    public IconType? IconType { get; set; }

    [Parameter]
    public string? InfoClass { get; set; }

    [Parameter]
    public string? InfoIcon { get; set; }

    [Parameter]
    public string? SuccessClass { get; set; }

    [Parameter]
    public string? SuccessIcon { get; set; }

    [Parameter]
    public string? WarningClass { get; set; }

    [Parameter]
    public string? WarningIcon { get; set; }

    [Parameter]
    public string? ErrorClass { get; set; }

    [Parameter]
    public string? ErrorIcon { get; set; }

    [Parameter]
    public ToastPosition Position { get; set; } = ToastPosition.TopRight;

    [Parameter]
    public int Timeout { get; set; } = 5;

    [Parameter]
    public int MaxToastCount { get; set; } = int.MaxValue;

    [Parameter]
    public bool RemoveToastsOnNavigation { get; set; }

    [Parameter]
    public bool ShowProgressBar { get; set; }

    [Parameter]
    public RenderFragment? CloseButtonContent { get; set; }

    [Parameter]
    public bool ShowCloseButton { get; set; } = true;

    private string PositionClass { get; set; } = string.Empty;

    private List<ToastInstance> ToastList { get; set; } = new();
    private Queue<ToastInstance> ToastWaitingQueue { get; set; } = new();

    protected override void OnInitialized()
    {
        ToastService.OnShow += ShowToast;
        ToastService.OnShowComponent += ShowToast;
        ToastService.OnClearAll += ClearAll;
        ToastService.OnClearToasts += ClearToasts;
        ToastService.OnClearCustomToasts += ClearCustomToasts;


        if (RemoveToastsOnNavigation)
        {
            NavigationManager.LocationChanged += ClearToasts;
        }

        PositionClass = $"position-{Position.ToString().ToLower()}";

        if ((!string.IsNullOrEmpty(InfoIcon)
             || !string.IsNullOrEmpty(SuccessIcon)
             || !string.IsNullOrEmpty(WarningIcon)
             || !string.IsNullOrEmpty(ErrorIcon)
            ) && IconType == null)
        {
            throw new ArgumentException("If an icon is specified then IconType is a required parameter.");
        }
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

    private ToastSettings BuildToastSettings(ToastLevel level, RenderFragment message, string heading, Action? onclick)
    {
        return level switch
        {
            ToastLevel.Error => new ToastSettings(ToastLevel.Error, string.IsNullOrWhiteSpace(heading) ? "Error" : heading, message, IconType, "blazored-toast-error", ErrorClass ?? "", ErrorIcon ?? "", ShowProgressBar, MaxToastCount, onclick),
            ToastLevel.Info => new ToastSettings(ToastLevel.Info, string.IsNullOrWhiteSpace(heading) ? "Info" : heading, message, IconType, "blazored-toast-info", InfoClass ?? "", InfoIcon ?? "", ShowProgressBar, MaxToastCount, onclick),
            ToastLevel.Success => new ToastSettings(ToastLevel.Success, string.IsNullOrWhiteSpace(heading) ? "Success" : heading, message, IconType, "blazored-toast-success", SuccessClass ?? "", SuccessIcon ?? "", ShowProgressBar, MaxToastCount, onclick),
            ToastLevel.Warning => new ToastSettings(ToastLevel.Warning, string.IsNullOrWhiteSpace(heading) ? "Warning" : heading, message, IconType, "blazored-toast-warning", WarningClass ?? "", WarningIcon ?? "", ShowProgressBar, MaxToastCount, onclick),
            _ => throw new InvalidOperationException()
        };
    }

    private void ShowToast(ToastLevel level, RenderFragment message, string heading, Action? onClick)
    {
        InvokeAsync(() =>
        {
            var settings = BuildToastSettings(level, message, heading, onClick);
            var toast = new ToastInstance(settings);

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
    private void ShowEnqueuedToast()
    {
        InvokeAsync(() =>
        {
            var toast = ToastWaitingQueue.Dequeue();

            ToastList.Add(toast);

            StateHasChanged();
        });

    }

    private void ShowToast(Type contentComponent, ToastParameters? parameters, ToastInstanceSettings? settings)
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

            if (settings is null)
            {
                settings = new ToastInstanceSettings(Timeout, ShowProgressBar);
            }
            else
            {
                settings = new ToastInstanceSettings(Timeout != settings.Timeout ? settings.Timeout : Timeout,
                    ShowProgressBar != settings.ShowProgressBar ? settings.ShowProgressBar : ShowProgressBar);
            }

            var toastInstance = new ToastInstance(childContent, settings);

            ToastList.Add(toastInstance);

            StateHasChanged();
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
            ToastList.RemoveAll(x => x.BlazoredToast is null && x.ToastSettings?.ToastLevel == toastLevel);
            StateHasChanged();
        });
    }

    private void ClearCustomToasts()
    {
        InvokeAsync(() =>
        {
            ToastList.RemoveAll(x => x.BlazoredToast is not null);
            StateHasChanged();
        });
    }
}
