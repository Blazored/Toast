using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.TestExtensions;

public class InMemoryToastService : IToastService
{
    private readonly List<InMemoryToast> _toasts = new();
    public IReadOnlyList<InMemoryToast> Toasts => _toasts;
    
    public event Action<Type, ToastParameters?, Action<ToastSettings>?> OnShowComponent;
    public event Action<ToastLevel, RenderFragment, Action<ToastSettings>?>? OnShow;
    public event Action OnClearAll;
    public event Action<ToastLevel> OnClearToasts;
    public event Action OnClearCustomToasts;
    public event Action? OnClearQueue;
    public event Action<ToastLevel>? OnClearQueueToasts;

    public void ShowToast<TComponent>() where TComponent : IComponent 
        => _toasts.Add(new InMemoryToast(typeof(TComponent)));

    public void ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent 
        => _toasts.Add(new InMemoryToast(typeof(TComponent)));

    public void ShowToast<TComponent>(Action<ToastSettings>? settings) where TComponent : IComponent 
        => _toasts.Add(new InMemoryToast(typeof(TComponent)));

    public void ShowToast<TComponent>(ToastParameters parameters, Action<ToastSettings>? settings) where TComponent : IComponent 
        => _toasts.Add(new InMemoryToast(typeof(TComponent)));

    public void ShowError(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Error, message, settings);

    public void ShowError(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Error, message, settings);

    public void ShowInfo(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Info, message, settings);

    public void ShowInfo(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Info, message, settings);

    public void ShowSuccess(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Success, message, settings);

    public void ShowSuccess(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Success, message, settings);

    public void ShowToast(ToastLevel level, string message, Action<ToastSettings>? settings = null)
        => ShowToast(level, builder => builder.AddContent(0, message), settings);

    public void ShowToast(ToastLevel level, RenderFragment message, Action<ToastSettings>? settings = null)
        => _toasts.Add(new InMemoryToast(typeof(ToastInstance), level, message));

    public void ShowWarning(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Warning, message, settings);

    public void ShowWarning(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Warning, message,  settings);

    public void ClearAll()
           => _toasts.Clear();

    public void ClearToasts(ToastLevel toastLevel)
            => _toasts.RemoveAll(x => x.ToastType == typeof(ToastInstance) && x.ToastLevel == toastLevel);

    public void ClearWarningToasts()
            => _toasts.RemoveAll(x => x.ToastType == typeof(ToastInstance) && x.ToastLevel == ToastLevel.Warning);

    public void ClearInfoToasts()
            => _toasts.RemoveAll(x => x.ToastType == typeof(ToastInstance) && x.ToastLevel == ToastLevel.Info);

    public void ClearSuccessToasts()
            => _toasts.RemoveAll(x => x.ToastType == typeof(ToastInstance) && x.ToastLevel == ToastLevel.Success);

    public void ClearErrorToasts()
            => _toasts.RemoveAll(x => x.ToastType == typeof(ToastInstance) && x.ToastLevel == ToastLevel.Error);

    public void ClearCustomToasts()
            => _toasts.RemoveAll(x => x.ToastType != typeof(ToastInstance));

    public void ClearQueue()
            => throw new NotImplementedException();

    public void ClearQueueToasts(ToastLevel toastLevel)
            => throw new NotImplementedException();

    public void ClearQueueWarningToasts()
            => throw new NotImplementedException();

    public void ClearQueueInfoToasts()
            => throw new NotImplementedException();

    public void ClearQueueSuccessToasts()
            => throw new NotImplementedException();

    public void ClearQueueErrorToasts()
            => throw new NotImplementedException();
}
