using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.TestExtensions;

public class InMemoryToastService : IToastService
{
    private readonly List<InMemoryToast> _toasts = new();
    public IReadOnlyList<InMemoryToast> Toasts => _toasts;

    public event Func<Type, ToastParameters?, Action<ToastSettings>?, IToastInstance>? OnShowComponent;
    public event Func<ToastLevel, RenderFragment, Action<ToastSettings>?, IToastInstance>? OnShow;
    public event Action? OnClearAll;
    public event Action<ToastLevel>? OnClearToasts;
    public event Action? OnClearCustomToasts;
    public event Action? OnClearQueue;
    public event Action<ToastLevel>? OnClearQueueToasts;

    public IToastInstance ShowToast<TComponent>() where TComponent : IComponent
    {
        var instance = new InMemoryToast(typeof(TComponent));
        _toasts.Add(instance);
        return instance;
    }

    public IToastInstance ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent
    {
        var instance = new InMemoryToast(typeof(TComponent));
        _toasts.Add(instance);
        return instance;
    }

    public IToastInstance ShowToast<TComponent>(Action<ToastSettings>? settings) where TComponent : IComponent
    {
        var instance = new InMemoryToast(typeof(TComponent));
        _toasts.Add(instance);
        return instance;
    }

    public IToastInstance ShowToast<TComponent>(ToastParameters parameters, Action<ToastSettings>? settings) where TComponent : IComponent
    {
        var instance = new InMemoryToast(typeof(TComponent));
        _toasts.Add(instance);
        return instance;
    }

    public IToastInstance ShowError(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Error, message, settings);

    public IToastInstance ShowError(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Error, message, settings);

    public IToastInstance ShowInfo(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Info, message, settings);

    public IToastInstance ShowInfo(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Info, message, settings);

    public IToastInstance ShowSuccess(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Success, message, settings);

    public IToastInstance ShowSuccess(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Success, message, settings);

    public IToastInstance ShowToast(ToastLevel level, string message, Action<ToastSettings>? settings = null)
        => ShowToast(level, builder => builder.AddContent(0, message), settings);

    public IToastInstance ShowToast(ToastLevel level, RenderFragment message, Action<ToastSettings>? settings = null)
    {
        var instance = new InMemoryToast(typeof(IToastInstance), level, message);
        _toasts.Add(instance);
        return instance;
    }

    public IToastInstance ShowWarning(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Warning, message, settings);

    public IToastInstance ShowWarning(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Warning, message, settings);

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
