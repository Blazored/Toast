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
    public bool? DisableTimeout { get; set; }

    /// <summary>
    /// Setting this property will override the global toast position property and allows you to set a specific position for this toast notification. The position can be set to one of the predefined values in the <c>ToastPosition</c> enumeration.
    /// </summary>
    public ToastPosition? Position { get; set; }    

    internal string PositionClass => $"position-{Position?.ToString().ToLower()}";

    public ToastSettings(
        string additionalClasses,
        IconType? iconType,
        string icon,
        bool showProgressBar,
        bool showCloseButton,
        Action? onClick,
        int timeout,
        bool disableTimeout,
        ToastPosition? toastPosition)
    {
        AdditionalClasses = additionalClasses;
        IconType = iconType;
        Icon = icon;
        ShowProgressBar = showProgressBar;
        ShowCloseButton = showCloseButton;
        OnClick = onClick;
        Timeout = timeout;
        DisableTimeout = disableTimeout;
        Position = toastPosition;

        if (onClick is not null)
        {
            AdditionalClasses += " blazored-toast-action";
        }
    }
    
#pragma warning disable CS8618
    internal ToastSettings() { }
#pragma warning restore CS8618
}
