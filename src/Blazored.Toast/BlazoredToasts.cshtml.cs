using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Blazored.Toast
{
    public class BlazoredToastsBase : ComponentBase
    {
        [Inject] private IToastService ToastService { get; set; }

        protected string Css { get; set; } = string.Empty;
        protected Dictionary<Guid, RenderFragment> ToastList { get; set; } = new Dictionary<Guid, RenderFragment>();

        protected override void OnInit()
        {
            ToastService.OnShow += ShowToast;
        }

        public void RemoveToast(Guid toastId)
        {
            Invoke(() =>
            {
                ToastList.Remove(toastId);

                StateHasChanged();
            });
        }

        private ToastSettings BuildToastSettings(ToastLevel level, string message, string heading)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Info" : heading, message, "toast-info", "");

                case ToastLevel.Success:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Success" : heading, message, "toast-success", "");

                case ToastLevel.Warning:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Warning" : heading, message, "toast-warning", "");

                case ToastLevel.Error:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Error" : heading, message, "toast-error", "");
            }

            throw new InvalidOperationException();
        }

        private void ShowToast(ToastLevel level, string message, string heading)
        {
            var settings = BuildToastSettings(level, message, heading);
            var options = ToastService.ToastOptions;
            var toastId = Guid.NewGuid();
            var toast = new RenderFragment(b =>
            {
                b.OpenComponent<BlazoredToast>(0);
                b.AddAttribute(1, "ToastSettings", settings);
                b.AddAttribute(2, "ToastId", toastId);
                b.CloseComponent();
            });

            Css = $"position-{options.Position.ToString().ToLower()}";
            ToastList.Add(toastId, toast);

            var timeout = options.Timeout * 1000;
            var toastTimer = new Timer(timeout);
            toastTimer.Elapsed += (sender, args) => { RemoveToast(toastId); };
            toastTimer.AutoReset = false;
            toastTimer.Start();

            StateHasChanged();
        }
    }
}
