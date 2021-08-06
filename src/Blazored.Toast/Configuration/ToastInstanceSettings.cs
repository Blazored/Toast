namespace Blazored.Toast
{
    public class ToastInstanceSettings
    {
        public int Timeout { get; } = 5;
        public bool ShowProgressBar { get; }

        public ToastInstanceSettings(int timeout)
        {
            Timeout = timeout;
        }

        public ToastInstanceSettings(bool showProgressBar)
        {
            ShowProgressBar = showProgressBar;
        }

        public ToastInstanceSettings(int timeout, bool showProgressBar)
        {
            Timeout = timeout;
            ShowProgressBar = showProgressBar;
        }
    }
}
