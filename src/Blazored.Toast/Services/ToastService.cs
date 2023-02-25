using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Services;

public class ToastService : IToastService
{
    /// <summary>
    /// A event that will be invoked when showing a toast
    /// </summary>
    public event Func<ToastLevel, RenderFragment, Action<ToastSettings>?, ToastInstance>? OnShow;

    /// <summary>
    /// A event that will be invoked when clearing all toasts
    /// </summary>
    public event Action? OnClearAll;

    /// <summary>
    /// A event that will be invoked when showing a toast with a custom component
    /// </summary>
    public event Func<Type, ToastParameters?, Action<ToastSettings>?, ToastInstance>? OnShowComponent;

    /// <summary>
    /// A event that will be invoked when clearing toasts
    /// </summary>
    public event Action<ToastLevel>? OnClearToasts;

    /// <summary>
    /// A event that will be invoked when clearing custom toast components
    /// </summary>
    public event Action? OnClearCustomToasts;

    /// <summary>
    /// A event that will be invoked to clear all queued toasts
    /// </summary>
    public event Action? OnClearQueue;

    /// <summary>
    /// A event that will be invoked to clear queued toast of specified level
    /// </summary>
    public event Action<ToastLevel>? OnClearQueueToasts;

    /// <summary>
    /// Shows a information toast 
    /// </summary>
    /// <returns>
    /// ToastInstance
    /// </returns>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowInfo(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Info, message, settings);

    /// <summary>
    /// Shows a information toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowInfo(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Info, message, settings);

    /// <summary>
    /// Shows a success toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowSuccess(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Success, message, settings);

    /// <summary>
    /// Shows a success toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowSuccess(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Success, message, settings);

    /// <summary>
    /// Shows a warning toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowWarning(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Warning, message, settings);

    /// <summary>
    /// Shows a warning toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowWarning(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Warning, message, settings);

    /// <summary>
    /// Shows a error toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowError(string message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Error, message, settings);

    /// <summary>
    /// Shows a error toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowError(RenderFragment message, Action<ToastSettings>? settings = null)
        => ShowToast(ToastLevel.Error, message, settings);

    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="level">Toast level to display</param>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowToast(ToastLevel level, string message, Action<ToastSettings>? settings = null)
        => ShowToast(level, builder => builder.AddContent(0, message), settings);


    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="level">Toast level to display</param>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowToast(ToastLevel level, RenderFragment message, Action<ToastSettings>? settings = null)
        => OnShow!.Invoke(level, message, settings);

    /// <summary>
    /// Shows the toast with the component type
    /// </summary>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowToast<TComponent>() where TComponent : IComponent
        => ShowToast(typeof(TComponent), new ToastParameters(), null);

    /// <summary>
    /// Shows the toast with the component type />,
    /// passing the specified <paramref name="parameters"/> 
    /// </summary>
    /// <param name="contentComponent">Type of component to display.</param>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
    /// <param name="settings">Settings to configure the toast component.</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowToast(Type contentComponent, ToastParameters? parameters, Action<ToastSettings>? settings)
    {
        if (!typeof(IComponent).IsAssignableFrom(contentComponent))
        {
            throw new ArgumentException($"{contentComponent.FullName} must be a Blazor Component");
        }

        return OnShowComponent!.Invoke(contentComponent, parameters, settings);
    }

    /// <summary>
    /// Shows the toast with the component type />,
    /// passing the specified <paramref name="parameters"/> 
    /// </summary>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent
        => ShowToast(typeof(TComponent), parameters, null);

    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="settings">Toast settings to be used</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowToast<TComponent>(Action<ToastSettings>? settings) where TComponent : IComponent
        => ShowToast(typeof(TComponent), null, settings);

    /// <summary>
    /// Shows a toast using the supplied parameter and settings
    /// </summary>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
    /// <param name="settings">Toast settings to be used</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    public ToastInstance ShowToast<TComponent>(ToastParameters parameters, Action<ToastSettings>? settings) where TComponent : IComponent
        => ShowToast(typeof(TComponent), parameters, settings);

    /// <summary>
    /// Removes all toasts
    /// </summary>
    public void ClearAll()
        => OnClearAll?.Invoke();

    /// <summary>
    /// Removes all toasts with a specified <paramref name="toastLevel"/>.
    /// </summary>
    public void ClearToasts(ToastLevel toastLevel)
        => OnClearToasts?.Invoke(toastLevel);

    /// <summary>
    /// Removes all toasts with toast level warning
    /// </summary>
    public void ClearWarningToasts()
        => OnClearToasts?.Invoke(ToastLevel.Warning);

    /// <summary>
    /// Removes all toasts with toast level info
    /// </summary>
    public void ClearInfoToasts()
        => OnClearToasts?.Invoke(ToastLevel.Info);

    /// <summary>
    /// Removes all toasts with toast level success
    /// </summary>
    public void ClearSuccessToasts()
        => OnClearToasts?.Invoke(ToastLevel.Success);

    /// <summary>
    /// Removes all toasts with toast level error
    /// </summary>
    public void ClearErrorToasts()
        => OnClearToasts?.Invoke(ToastLevel.Error);

    /// <summary>
    /// Removes all custom component toasts
    /// </summary>
    public void ClearCustomToasts()
        => OnClearCustomToasts?.Invoke();

    /// <summary>
    /// Removes all queued toasts
    /// </summary>
    /// 
    public void ClearQueue()
        => OnClearQueue?.Invoke();

    /// <summary>
    /// Removes all queued toasts with a specified <paramref name="toastLevel"/>.
    /// </summary>
    public void ClearQueueToasts(ToastLevel toastLevel)
        => OnClearQueueToasts?.Invoke(toastLevel);

    /// <summary>
    /// Removes all queued toasts with toast level warning
    /// </summary>
    public void ClearQueueWarningToasts()
        => OnClearQueueToasts?.Invoke(ToastLevel.Warning);

    /// <summary>
    /// Removes all queued toasts with toast level info
    /// </summary>
    public void ClearQueueInfoToasts()
        => OnClearQueueToasts?.Invoke(ToastLevel.Info);

    /// <summary>
    /// Removes all queued toasts with toast level success
    /// </summary>
    public void ClearQueueSuccessToasts()
        => OnClearQueueToasts?.Invoke(ToastLevel.Success);

    /// <summary>
    /// Removes all queued toasts with toast level error
    /// </summary>
    public void ClearQueueErrorToasts()
        => OnClearQueueToasts?.Invoke(ToastLevel.Error);
}
