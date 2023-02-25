using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Services;

public interface IToastService
{
    /// <summary>
    /// A event that will be invoked when showing a toast
    /// </summary>
    event Func<ToastLevel, RenderFragment, Action<ToastSettings>?, IToastInstance> OnShow;

    /// <summary>
    /// A event that will be invoked to clear all toasts
    /// </summary>
    event Action? OnClearAll;

    /// <summary>
    /// A event that will be invoked to clear toast of specified level
    /// </summary>
    event Action<ToastLevel>? OnClearToasts;

    /// <summary>
    /// A event that will be invoked to clear custom toast components
    /// </summary>
    event Action? OnClearCustomToasts;

    /// <summary>
    /// A event that will be invoked when showing a toast with a custom component
    /// </summary>
    event Func<Type, ToastParameters?, Action<ToastSettings>?, IToastInstance>? OnShowComponent;

    /// <summary>
    /// A event that will be invoked to clear all queued toasts
    /// </summary>
    event Action? OnClearQueue;

    /// <summary>
    /// A event that will be invoked to clear queue toast of specified level
    /// </summary>
    event Action<ToastLevel>? OnClearQueueToasts;

    /// <summary>
    /// Shows a information toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowInfo(string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a information toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowInfo(RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a success toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowSuccess(string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a success toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowSuccess(RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a warning toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowWarning(string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a warning toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowWarning(RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a error toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowError(string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a error toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowError(RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="level">Toast level to display</param>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowToast(ToastLevel level, string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="level">Toast level to display</param>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowToast(ToastLevel level, RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a toast containing the specified <typeparamref name="TComponent"/>.
    /// </summary>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowToast<TComponent>() where TComponent : IComponent;

    /// <summary>
    /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="parameters"/>.
    /// </summary>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent;

    /// <summary>
    /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="settings"/>.
    /// </summary>
    /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowToast<TComponent>(Action<ToastSettings> settings) where TComponent : IComponent;

    /// <summary>
    /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="settings" /> and <paramref name="parameters"/>.
    /// </summary>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed</param>
    /// /// <param name="settings">Settings to configure the toast instance</param>
    /// <returns>
    /// This method returns an object of type <see cref="ToastInstance"/>.
    /// </returns>
    IToastInstance ShowToast<TComponent>(ToastParameters parameters, Action<ToastSettings> settings) where TComponent : IComponent;

    /// <summary>
    /// Removes all toasts
    /// </summary>
    void ClearAll();

    /// <summary>
    /// Removes all toasts with a specified <paramref name="toastLevel"/>.
    /// </summary>
    void ClearToasts(ToastLevel toastLevel);

    /// <summary>
    /// Removes all toasts with toast level warning
    /// </summary>
    void ClearWarningToasts();

    /// <summary>
    /// Removes all toasts with toast level Info
    /// </summary>
    void ClearInfoToasts();

    /// <summary>
    /// Removes all toasts with toast level Success
    /// </summary>
    void ClearSuccessToasts();

    /// <summary>
    /// Removes all toasts with toast level Error
    /// </summary>
    void ClearErrorToasts();

    /// <summary>
    /// Removes all custom toast components
    /// </summary>
    void ClearCustomToasts();

    /// <summary>
    /// Removes all queued toasts
    /// </summary>
    void ClearQueue();

    /// <summary>
    /// Removes all queued toasts with a specified <paramref name="toastLevel"/>.
    /// </summary>
    void ClearQueueToasts(ToastLevel toastLevel);

    /// <summary>
    /// Removes all queued toasts with toast level warning
    /// </summary>
    void ClearQueueWarningToasts();

    /// <summary>
    /// Removes all queued toasts with toast level Info
    /// </summary>
    void ClearQueueInfoToasts();

    /// <summary>
    /// Removes all queued toasts with toast level Success
    /// </summary>
    void ClearQueueSuccessToasts();

    /// <summary>
    /// Removes all queued toasts with toast level Error
    /// </summary>
    void ClearQueueErrorToasts();
}
