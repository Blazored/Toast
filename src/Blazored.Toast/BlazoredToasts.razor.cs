using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

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
        }

        public void RemoveToast(Guid toastId)
        {
            if (ToastList.Count == 1)
            {
                ToastList.Clear();
            }
            else
            {
                var t = ToastList.SingleOrDefault(x => x.Id == toastId);
                var found = t == null;
                Console.WriteLine(found);

                if (!found)
                {
                    Console.WriteLine(toastId);
                    foreach (var toast in ToastList)
                    {
                        Console.WriteLine(toast.Id);
                    }
                }

                ToastList.Remove(t);
            }

            StateHasChanged();

            Console.WriteLine("List Count:" + ToastList.Count);
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
            var toast = new Toast
            {
                Id = Guid.NewGuid(),
                TimeStamp = DateTime.Now,
                ToastSettings = settings,
                Options = options
            };

            Css = $"position-{options.Position.ToString().ToLower()}";
            ToastList.Add(toast);

            StateHasChanged();
        }
    }
}
