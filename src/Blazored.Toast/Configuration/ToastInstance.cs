using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast.Configuration
{
    public class ToastInstance
    {
        internal ToastInstance(ToastSettings toastSettings)
        {
            ToastSettings = toastSettings;
        }
        internal ToastInstance(RenderFragment blazoredToast, ToastInstanceSettings settings)
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
