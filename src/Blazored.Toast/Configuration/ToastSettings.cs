using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast.Configuration
{
    public class ToastSettings
    {
        public ToastSettings(
            string heading,
            RenderFragment message,
            IconType? iconType,
            string baseClass,
            string additionalClasses,
            string icon,
            bool showProgressBar,
            TimeSpan? closeDelay)
        {
            Heading = heading;
            Message = message;
            IconType = iconType;
            BaseClass = baseClass;
            AdditionalClasses = additionalClasses;
            Icon = icon;
            ShowProgressBar = showProgressBar;
            CloseDelay = closeDelay;
        }

        public string Heading { get; set; }
        public RenderFragment Message { get; set; }
        public string BaseClass { get; set; }
        public string AdditionalClasses { get; set; }
        public string Icon { get; set; }
        public IconType? IconType { get; set; }
        public bool ShowProgressBar { get; set; }
        public TimeSpan? CloseDelay { get; set; }
    }
}
