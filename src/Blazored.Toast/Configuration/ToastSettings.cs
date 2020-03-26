using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Configuration
{
    public class ToastSettings
    {
        public ToastSettings(string heading, RenderFragment message, string baseClass, string additionalClasses, string iconClass)
        {
            Heading = heading;
            Message = message;
            BaseClass = baseClass;
            AdditionalClasses = additionalClasses;
            IconClass = iconClass;
        }

        public string Heading { get; set; }
        public RenderFragment Message { get; set; }
        public string BaseClass { get; set; }
        public string AdditionalClasses { get; set; }
        public string IconClass { get; set; }
    }
}
