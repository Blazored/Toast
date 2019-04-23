using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;
using System;
using System.Timers;

namespace Blazored.Toast
{
    public class BlazoredToastBase : ComponentBase
    {
        [Parameter] protected Guid ToastId { get; set; }
        [Parameter] protected ToastSettings ToastSettings { get; set; }
        [Parameter] protected ToastOptions ToastOptions { get; set; }
        [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; }

        protected override void OnInit()
        {
            var timeout = ToastOptions.Timeout * 1000;
            var toastTimer = new Timer(timeout);
            toastTimer.Elapsed += HideToast;
            toastTimer.AutoReset = false;
            toastTimer.Start();
        }

        protected void HideToast(object sender, ElapsedEventArgs args)
        {
            Console.WriteLine("Hide Called");
            Close();
        }

        protected void Close()
        {
            ToastsContainer.RemoveToast(ToastId);
        }
    }
}
