using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast.Configuration
{
    public class ToastInstance
    {
        public ToastInstance(ToastSettings toastSettings)
        {
            ToastSettings = toastSettings;
        }
        public ToastInstance(RenderFragment blazoredToast, ToastComponentSettings settings)
        {
            BlazoredToast = blazoredToast;
            ToastComponentSettings = settings;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public DateTime TimeStamp { get; } = DateTime.Now;
        public ToastSettings ToastSettings { get; }
        public ToastComponentSettings ToastComponentSettings { get; }
        public RenderFragment BlazoredToast { get; }
    }
}
