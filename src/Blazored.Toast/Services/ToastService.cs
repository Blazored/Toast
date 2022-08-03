using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Services;

public class ToastService : IToastService
{
    /// <summary>
    /// A event that will be invoked when showing a toast
    /// </summary>
    public event Action<ToastLevel, RenderFragment, string, Action> OnShow;

    /// <summary>
    /// A event that will be invoked when clearing all toasts
    /// </summary>
    public event Action OnClearAll;

    /// <summary>
    /// A event that will be invoked when showing a toast with a custom comonent
    /// </summary>
    public event Action<Type, ToastParameters, ToastInstanceSettings> OnShowComponent;

    /// <summary>
    /// A event that will be invoked when clearing toasts
    /// </summary>
    public event Action<ToastLevel> OnClearToasts;

    /// <summary>
    /// A event that will be invoked when clearing custom toast components
    /// </summary>
    public event Action OnClearCustomToasts;

    /// <summary>
    /// Shows a information toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowInfo(string message, string heading = "", Action? onClick = null)
        => ShowToast(ToastLevel.Info, message, heading, onClick);

    /// <summary>
    /// Shows a information toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowInfo(RenderFragment message, string heading = "", Action? onClick = null)
        => ShowToast(ToastLevel.Info, message, heading, onClick);

    /// <summary>
    /// Shows a success toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowSuccess(string message, string heading = "", Action? onClick = null)
        => ShowToast(ToastLevel.Success, message, heading, onClick);

    /// <summary>
    /// Shows a success toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowSuccess(RenderFragment message, string heading = "", Action? onClick = null)
        => ShowToast(ToastLevel.Success, message, heading, onClick);

    /// <summary>
    /// Shows a warning toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowWarning(string message, string heading = "", Action? onClick = null)
        => ShowToast(ToastLevel.Warning, message, heading, onClick);

    /// <summary>
    /// Shows a warning toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowWarning(RenderFragment message, string heading = "", Action? onClick = null)
        => ShowToast(ToastLevel.Warning, message, heading, onClick);

    /// <summary>
    /// Shows a error toast 
    /// </summary>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowError(string message, string heading = "", Action? onClick = null)
        => ShowToast(ToastLevel.Error, message, heading, onClick);

    /// <summary>
    /// Shows a error toast 
    /// </summary>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowError(RenderFragment message, string heading = "", Action? onClick = null)
        => ShowToast(ToastLevel.Error, message, heading, onClick);

    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="level">Toast level to display</param>
    /// <param name="message">Text to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowToast(ToastLevel level, string message, string heading = "", Action? onClick = null)
        => ShowToast(level, builder => builder.AddContent(0, message), heading, onClick);


    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="level">Toast level to display</param>
    /// <param name="message">RenderFragment to display on the toast</param>
    /// <param name="heading">The text to display as the toasts heading</param>
    /// <param name="onClick">Action to be executed on click</param>
    public void ShowToast(ToastLevel level, RenderFragment message, string heading = "", Action? onClick = null)
        => OnShow?.Invoke(level, message, heading, onClick);

    /// <summary>
    /// Shows the toast with the component type
    /// </summary>
    public void ShowToast<TComponent>() where TComponent : IComponent
        => ShowToast(typeof(TComponent), new ToastParameters(), null);

    /// <summary>
    /// Shows the toast with the component type />,
    /// passing the specified <paramref name="parameters"/> 
    /// </summary>
    /// <param name="contentComponent">Type of component to display.</param>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
    /// <param name="settings">Settings to configure the toast component.</param>
    public void ShowToast(Type contentComponent, ToastParameters parameters, ToastInstanceSettings settings)
    {
        if (!typeof(IComponent).IsAssignableFrom(contentComponent))
        {
            throw new ArgumentException($"{contentComponent.FullName} must be a Blazor Component");
        }
        OnShowComponent?.Invoke(contentComponent, parameters, settings);
    }

    /// <summary>
    /// Shows the toast with the component type />,
    /// passing the specified <paramref name="parameters"/> 
    /// </summary>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
    public void ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent
        => ShowToast(typeof(TComponent), parameters, null);

    /// <summary>
    /// Shows a toast using the supplied settings
    /// </summary>
    /// <param name="settings">Toast settings to be used</param>
    public void ShowToast<TComponent>(ToastInstanceSettings settings) where TComponent : IComponent
        => ShowToast(typeof(TComponent), null, settings);

    /// <summary>
    /// Shows a toast using the supplied parameter and settings
    /// </summary>
    /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
    /// <param name="settings">Toast settings to be used</param>
    public void ShowToast<TComponent>(ToastParameters parameters, ToastInstanceSettings settings) where TComponent : IComponent
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
}
