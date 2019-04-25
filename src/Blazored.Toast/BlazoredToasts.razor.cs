using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Blazored.Toast
{
    public class BlazoredToastsBase : ComponentBase
    {
        [Inject] private IToastService ToastService { get; set; }

        protected string Css { get; set; } = string.Empty;
        internal List<Toast> ToastList { get; set; } = new List<Toast>();

        protected override void OnInit()
        {
            ToastService.OnShow += ShowToast;
            Css = $"position-{ToastService.ToastOptions.Position.ToString().ToLower()}";
        }

        public void RemoveToast(Guid toastId)
        {
            Invoke(() =>
            {
                var toastInstance = ToastList.SingleOrDefault(x => x.Id == toastId);
                ToastList.Remove(toastInstance);
                StateHasChanged();
            });
        }

        private ToastSettings BuildToastSettings(ToastLevel level, string message, string heading)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Info" : heading, message, "blazored-toast-info", "");

                case ToastLevel.Success:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Success" : heading, message, "blazored-toast-success", "");

                case ToastLevel.Warning:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Warning" : heading, message, "blazored-toast-warning", "");

                case ToastLevel.Error:
                    return new ToastSettings(string.IsNullOrWhiteSpace(heading) ? "Error" : heading, message, "blazored-toast-error", "");
            }

            throw new InvalidOperationException();
        }

        private void ShowToast(ToastLevel level, string message, string heading)
        {
            var settings = BuildToastSettings(level, message, heading);
            var options = ToastService.ToastOptions;
            var toast = new Toast
            {
                Id = Guid.NewGuid(),
                TimeStamp = DateTime.Now,
                ToastSettings = settings,
                Options = options
            };

            ToastList.Add(toast);

            var timeout = options.Timeout * 1000;
            var toastTimer = new Timer(timeout);
            toastTimer.Elapsed += (sender, args) => { RemoveToast(toast.Id); };
            toastTimer.AutoReset = false;
            toastTimer.Start();

            StateHasChanged();
        }
    }
}
