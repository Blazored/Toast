﻿namespace Blazored.Toast.Configuration;
public class ToastSettings
{
    /// <summary>
    /// The <c>AdditionalClasses</c> property is used to specify additional CSS classes that will be applied to the toast component. 
    /// </summary>
    /// <remarks>
    /// By setting this property, you can customize the appearance of the toast notification and apply custom styles to it. Note that the value of the <c>AdditionalClasses</c> property should be a string containing one or more CSS class names separated by spaces.
    /// </remarks>
    public string AdditionalClasses { get; set; }

    /// <summary>
    /// The possible values for the <c>Icon</c> property are names of icons from the FontAwesome and Material icon libraries. By providing the name of the desired icon, the corresponding icon will be displayed on the notification.
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    /// The <c>IconType</c> property determines the type of icon that will be displayed on the toast notification. This property is an optional feature that can be used to provide users with additional visual cues about the notification.
    /// </summary>
    public IconType? IconType { get; set; }

    /// <summary>
    /// Enabling the <c>ShowProgressBar</c> property provides visual feedback on the remaining time for the toast notification based on the <c>Timeout</c> property. 
    /// </summary>    
    public bool ShowProgressBar { get; set; }

    /// <summary>
    /// When the <c>PauseProgressOnHover</c> property is enabled, the timeout period for the toast notification will be paused when the user hovers the mouse over the toast.
    /// </summary>    
    /// <remarks>
    /// This can be useful for providing users with more time to read the contents of the notification. By using the <c>PauseProgressOnHover</c> property in conjunction with the <c>ExtendedTimeout</c> property, you can create a toast notification that is more user-friendly and provides better visual feedback to the user.
    /// </remarks>
    public bool? PauseProgressOnHover { get; set; }

    /// <summary>
    /// The ShowCloseButton property determines whether or not the close button is displayed on the toast notification.
    /// </summary>
    public bool ShowCloseButton { get; set; }

    /// <summary>
    /// The <c>OnClick</c> property is an optional action that is triggered when the user clicks on the toast notification.
    /// </summary>
    /// <remarks>
    /// This property allows you to define a custom action that will be executed when the user interacts with the notification, such as opening a new window or performing some other action.
    /// </remarks>
    public Action? OnClick { get; set; }

    /// <summary>
    /// The <c>Timeout</c> property determines the amount of time, in seconds, that the toast notification will be displayed before it is automatically closed.
    /// </summary>
    /// <remarks>
    /// By setting this property, you can control the duration of the notification and ensure that it is visible to the user for an appropriate amount of time.
    /// </remarks>
    public int Timeout { get; set; }

    /// <summary>    
    /// When <c>PauseProgressOnHover</c> is enabled, the <c>ExtendedTimeout</c> property determines the amount of time, in seconds, that the toast notification will remain visible after the user moves the mouse away from it.
    /// </summary>
    /// <remarks>
    /// Default value is <c>0</c>, meaning no extended timeout.
    /// </remarks>
    public int ExtendedTimeout { get; set; }

    public ToastSettings(
        string additionalClasses,
        IconType? iconType,
        string icon,
        bool showProgressBar,
        bool showCloseButton,
        Action? onClick,
        int timeout,
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
