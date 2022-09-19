using Microsoft.AspNetCore.Components;
using System;
using Blazored.Toast.Services;

namespace Blazored.Toast.Configuration;

internal class ToastInstance
{
    public ToastInstance(RenderFragment message, ToastLevel level, ToastSettings toastSettings)
    {
        Message = message;
        Level = level;
        ToastSettings = toastSettings;
    }
    public ToastInstance(RenderFragment customComponent, ToastSettings settings)
    {
        CustomComponent = customComponent;
        ToastSettings = settings;
    }

    public Guid Id { get; } = Guid.NewGuid();
    public DateTime TimeStamp { get; } = DateTime.Now;
    public RenderFragment? Message { get; set; }
    public ToastLevel Level { get; }
    public ToastSettings ToastSettings { get; }
    public RenderFragment? CustomComponent { get; }
}
