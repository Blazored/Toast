using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast.Configuration
{
    internal class ToastInstance
    {
        public ToastInstance(ToastSettings toastSettings)
        {
            ToastSettings = toastSettings;
        }
        public ToastInstance(RenderFragment blazoredToast, ToastInstanceSettings settings)
        {
            BlazoredToast = blazoredToast;
            ToastInstanceSettings = settings;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public ToastSettings ToastSettings { get; set; }
        public ToastInstanceSettings ToastInstanceSettings { get; }
        public RenderFragment BlazoredToast { get; }
    }
}
