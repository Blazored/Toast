namespace Blazored.Toast;

public class ToastInstanceSettings
{
    public int Timeout { get; }
    public bool ShowProgressBar { get; }

    public ToastInstanceSettings(int timeout, bool showProgressBar)
    {
        Timeout = timeout;
        ShowProgressBar = showProgressBar;
    }
}
