using Microsoft.AspNetCore.Components;
using System;
using Blazored.Toast.Services;

namespace Blazored.Toast.Configuration;

public  class ToastInstance: IDisposable, IToastInstance
{
    internal ToastInstance(RenderFragment message, ToastLevel level, ToastSettings toastSettings, Action<Guid> onClose)
    {
        Message = message;
        Level = level;
        ToastSettings = toastSettings;
        OnClose += onClose;
    }
    internal ToastInstance(RenderFragment customComponent, ToastSettings settings, Action<Guid> onClose)
    {
        CustomComponent = customComponent;
        ToastSettings = settings;
        OnClose += onClose;
    }

    internal event Action<Guid> OnClose;
    public Guid Id { get; } = Guid.NewGuid();
    internal DateTime TimeStamp { get; } = DateTime.Now;
    internal RenderFragment? Message { get; set; }
    internal ToastLevel Level { get; }
    internal ToastSettings ToastSettings { get; }
    internal RenderFragment? CustomComponent { get; }

    public void Close()
        => OnClose?.Invoke(Id);

    //todo remove comment after review
    //i am not sure if this was 
    public void Dispose()
    {
        OnClose -= OnClose;
        GC.SuppressFinalize(this);
    } 
}
