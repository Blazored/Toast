using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Configuration;

public class ToastSettings
{
    public string AdditionalClasses { get; set; }
    public string? Icon { get; set; }
    public IconType? IconType { get; set; }
    public bool ShowProgressBar { get; set; }
    public bool ShowCloseButton { get; set; }
    public Action? OnClick { get; set; }
    public int Timeout { get; set; }
    
    public ToastSettings(
        string additionalClasses,
        IconType? iconType,
        string icon,
        bool showProgressBar,
        bool showCloseButton,
        Action? onClick,
        int timeout)
    {
        AdditionalClasses = additionalClasses;
        IconType = iconType;
        Icon = icon;
        ShowProgressBar = showProgressBar;
        ShowCloseButton = showCloseButton;
        OnClick = onClick;
        Timeout = timeout;

        if (onClick is not null)
        {
            AdditionalClasses += " blazored-toast-action";
        }
    }
    
#pragma warning disable CS8618
    internal ToastSettings() { }
#pragma warning restore CS8618
}
