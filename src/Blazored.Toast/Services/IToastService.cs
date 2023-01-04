using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Services;

public interface IToastService
{
    /// <summary>
    /// A event that will be invoked when showing a toast
    /// </summary>
    event Action<ToastLevel, RenderFragment, Action<ToastSettings>?> OnShow;

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
    event Action<Type, ToastParameters?, Action<ToastSettings>?>? OnShowComponent;

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
    void ShowInfo(string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a information toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowInfo(RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a success toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowSuccess(string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a success toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowSuccess(RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a warning toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowWarning(string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a warning toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowWarning(RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a error toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowError(string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a error toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowError(RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="level">Toast level to display</param>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowToast(ToastLevel level, string message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="level">Toast level to display</param>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowToast(ToastLevel level, RenderFragment message, Action<ToastSettings>? settings = null);

    /// <summary>
    /// Shows a toast containing the specified <typeparamref name="TComponent"/>.
    /// </summary>
    void ShowToast<TComponent>() where TComponent : IComponent;

    /// <summary>
    /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="parameters"/>.
    /// </summary>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed</param>
    void ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent;

    /// <summary>
    /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="settings"/>.
    /// </summary>
    /// <param name="settings">Settings to configure the toast instance</param>
    void ShowToast<TComponent>(Action<ToastSettings> settings) where TComponent : IComponent;

    /// <summary>
    /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="settings" /> and <paramref name="parameters"/>.
    /// </summary>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed</param>
    /// /// <param name="settings">Settings to configure the toast instance</param>
    void ShowToast<TComponent>(ToastParameters parameters, Action<ToastSettings> settings) where TComponent : IComponent;

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
