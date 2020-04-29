namespace Blazored.Toast.Configuration
{
    public class ToastSettings
    {
        public ToastSettings(
            string heading, 
            string message,
            IconType iconType,
            string baseClass,
            string additionalClasses,
            string iconName)
        {
            Heading = heading;
            Message = message;
            IconType = iconType;
            BaseClass = baseClass;
            AdditionalClasses = additionalClasses;
            IconSelector = iconName;
        }

        public string Heading { get; set; }
        public string Message { get; set; }
        public string BaseClass { get; set; }
        public string AdditionalClasses { get; set; }
        public string IconSelector { get; set; }
        public IconType IconType { get; set; }
    }
}
