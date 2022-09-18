using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Configuration;

public class ToastSettings
{
    public ToastSettings(
        ToastLevel toastLevel,
        string? heading,
        RenderFragment message,
        IconType? iconType,
        string baseClass,
        string additionalClasses,
        string icon,
        bool showProgressBar,
        int maxItemsShown,
        Action? onClick)
    {
        ToastLevel = toastLevel;
        Heading = heading;
        Message = message;
        IconType = iconType;
        BaseClass = baseClass;
        AdditionalClasses = additionalClasses;
        Icon = icon;
        ShowProgressBar = showProgressBar;
        MaxItemsShown = maxItemsShown;
        OnClick = onClick;
        
        if (onClick is not null)
        {
            AdditionalClasses += " blazored-toast-action";
        }
    }

    public ToastLevel ToastLevel { get; }
    public string? Heading { get; }
    public RenderFragment Message { get; }
    public string BaseClass { get; }
    public string AdditionalClasses { get; }
    public string Icon { get; }
    public IconType? IconType { get; }
    public bool ShowProgressBar { get; }
    public int MaxItemsShown { get; }
    public Action? OnClick { get; }
}
