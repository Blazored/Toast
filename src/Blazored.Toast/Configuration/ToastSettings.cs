namespace Blazored.Toast.Configuration
{
    public class ToastSettings
    {
        public ToastSettings(string heading, string message, string cssClasses, string iconClass)
        {
            Heading = heading;
            Message = message;
            CssClasses = cssClasses;
            IconClass = iconClass;
        }

        public string Heading { get; set; }
        public string Message { get; set; }
        public string CssClasses { get; set; }
        public string IconClass { get; set; }
    }
}
