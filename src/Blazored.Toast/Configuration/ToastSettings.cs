using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Configuration;

public class ToastSettings
{
    public ToastSettings(
        ToastLevel toastLevel,
        string heading,
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
        if (onClick != null)
        {
            AdditionalClasses += " blazored-toast-action";
        }
    }

    public ToastLevel ToastLevel { get; set; }
    public string Heading { get; set; }
    public RenderFragment Message { get; set; }
    public string BaseClass { get; set; }
    public string AdditionalClasses { get; set; }
    public string Icon { get; set; }
    public IconType? IconType { get; set; }
    public bool ShowProgressBar { get; set; }
    public int MaxItemsShown { get; set; }
    public Action? OnClick { get; set; }
}
