﻿using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazored.Toast
{
    public enum IconType { FontAwesome, Material };

    public partial class BlazoredToasts
    {
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public IconType? IconType { get; set; }
        [Parameter] public string InfoClass { get; set; }
        [Parameter] public string InfoIcon { get; set; }
        [Parameter] public string SuccessClass { get; set; }
        [Parameter] public string SuccessIcon { get; set; }
        [Parameter] public string WarningClass { get; set; }
        [Parameter] public string WarningIcon { get; set; }
        [Parameter] public string ErrorClass { get; set; }
        [Parameter] public string ErrorIcon { get; set; }
        [Parameter] public ToastPosition Position { get; set; } = ToastPosition.TopRight;
        [Parameter] public int Timeout { get; set; } = 5;
        [Parameter] public bool RemoveToastsOnNavigation { get; set; }
        [Parameter] public bool ShowProgressBar { get; set; }

        private string PositionClass { get; set; } = string.Empty;
        internal List<ToastInstance> ToastList { get; set; } = new List<ToastInstance>();

        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;
            ToastService.OnShowComponent += ShowToast;


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
                ToastList.Remove(toastInstance);
                StateHasChanged();
            });
        }

        private void ClearToasts(object sender, LocationChangedEventArgs args)
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();
            });
        }

        private ToastSettings BuildToastSettings(ToastLevel level, RenderFragment message, string heading, Action? onclick)
        {
            switch (level)
            {
                case ToastLevel.Error:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Error" : heading, message, IconType,
                        "blazored-toast-error", ErrorClass, ErrorIcon, ShowProgressBar, onclick);

                case ToastLevel.Info:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Info" : heading, message, IconType,
                        "blazored-toast-info", InfoClass, InfoIcon, ShowProgressBar, onclick);

                case ToastLevel.Success:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Success" : heading, message, IconType,
                        "blazored-toast-success", SuccessClass, SuccessIcon, ShowProgressBar, onclick);

                case ToastLevel.Warning:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Warning" : heading, message, IconType,
                        "blazored-toast-warning", WarningClass, WarningIcon, ShowProgressBar, onclick);
            }

            throw new InvalidOperationException();
        }

        private void ShowToast(ToastLevel level, RenderFragment message, string heading, Action? onClick)
        {
            InvokeAsync(() =>
            {
                var settings = BuildToastSettings(level, message, heading, onClick);
                var toast = new ToastInstance(settings);

                ToastList.Add(toast);

                StateHasChanged();
            });

        }

        private void ShowToast(Type contentComponent, ToastParameters parameters, ToastComponentSettings settings)
        {
            InvokeAsync(() =>
            {
                var childContent = new RenderFragment(builder =>
                {
                    var i = 0;
                    builder.OpenComponent(i++, contentComponent);
                    if (parameters is object)
                    {
                        foreach (var parameter in parameters._parameters)
                        {
                            builder.AddAttribute(i++, parameter.Key, parameter.Value);
                        }
                    }
                    builder.CloseComponent();
                });

                if (settings == null)
                {
                    settings = new ToastComponentSettings(Timeout, ShowProgressBar);
                }
                else
                {
                    settings = new ToastComponentSettings(Timeout != settings.Timeout ? settings.Timeout : Timeout,
                        ShowProgressBar != settings.ShowProgressBar ? settings.ShowProgressBar : ShowProgressBar);
                }

                var toastInstance = new ToastInstance(childContent, settings);

                ToastList.Add(toastInstance);

                StateHasChanged();
            });
        }
    }
}
