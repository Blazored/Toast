namespace Blazored.Toast
{
    public class ToastSettings
    {
        public ToastSettings(string heading, string message, string backgroundClass, string iconClass)
        {
            Heading = heading;
            Message = message;
            BackgroundClass = backgroundClass;
            IconClass = iconClass;
        }

        public string BackgroundClass { get; set; }
        public string Heading { get; set; }
        public string IconClass { get; set; }
        public string Message { get; set; }
    }
}
