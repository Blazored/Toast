using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Configuration;

public class ToastSettings
{
    /// <summary>
    /// Add additional classes that will be applied to toast component
    /// </summary>
    public string AdditionalClasses { get; set; }
    /// <summary>
    /// Icon name, currently supporeted names for FontAwesome icons, Material icons
    /// </summary>
    public string? Icon { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public IconType? IconType { get; set; }
    /// <summary>
    /// When enabled progress will be shown until toaster is closed based on  <see cref="Timeout"/> value
    /// </summary>    
    public bool ShowProgressBar { get; set; }
    /// <summary>
    /// When enabled and mouse is over the toast, timeout period will be paused.
    /// Use this with <see cref="ExtendedTimeout"/>
    /// </summary>
    public bool PauseProgressOnHover { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool ShowCloseButton { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Action? OnClick { get; set; }
    /// <summary>
    /// Timeout in seconds for toaster to close
    /// </summary>
    public int Timeout { get; set; }
    
    /// <summary>    
    /// When <see cref="PauseProgressOnHover"/> is enabled, set ExtentedTimeout in seconds
    /// to close toast after mouse loose focus.
    /// Default value is 0, meaning no extended timeout
    /// </summary>
    public int ExtendedTimeout { get; set; }

    /// <summary>
    /// Setting the <c>DisableTimeout</c> property to true will prevent the toast notification from automatically closing based on the duration specified by the <c>Timeout</c> and <c>ExtendedTimeout</c> properties. 
    /// </summary>
    /// <remarks>
    /// Use this property if you want the user to dismiss the notification manually.
    /// </remarks>
    public bool? DisableTimeout { get; set; }
    
    public ToastSettings(
        string additionalClasses,
        IconType? iconType,
        string icon,
        bool showProgressBar,
        bool showCloseButton,
        Action? onClick,
        int timeout,
        bool disableTimeout,
        bool pauseProgressOnHover,
        int extendedTimeout)
    {
        AdditionalClasses = additionalClasses;
        IconType = iconType;
        Icon = icon;
        ShowProgressBar = showProgressBar;
        ShowCloseButton = showCloseButton;
        OnClick = onClick;
        Timeout = timeout;
        DisableTimeout = disableTimeout;
        PauseProgressOnHover = pauseProgressOnHover;
        ExtendedTimeout = extendedTimeout;

        if (onClick is not null)
        {
            AdditionalClasses += " blazored-toast-action";
        }
        ExtendedTimeout = extendedTimeout;
    }

#pragma warning disable CS8618
    internal ToastSettings() { }
#pragma warning restore CS8618
}
