namespace Blazored.Toast
{
    public class ToastComponentSettings
    {
        public int Timeout { get; } = 5;
        public bool ShowProgressBar { get; }

        public ToastComponentSettings(int timeout)
        {
            Timeout = timeout;
        }

        public ToastComponentSettings(bool showProgressBar)
        {
            ShowProgressBar = showProgressBar;
        }

        public ToastComponentSettings(int timeout, bool showProgressBar)
        {
            Timeout = timeout;
            ShowProgressBar = showProgressBar;
        }
    }
}
