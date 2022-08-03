using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.TestExtensions;

public class InMemoryToastService : IToastService
{
    private readonly List<InMemoryToast> toasts = new List<InMemoryToast>();
    public IReadOnlyList<InMemoryToast> Toasts => toasts;

    public event Action<ToastLevel, RenderFragment, string, Action> OnShow;

    public event Action<Type, ToastParameters, ToastInstanceSettings> OnShowComponent;
    public event Action OnClearAll;
    public event Action<ToastLevel> OnClearToasts;
    public event Action OnClearCustomToasts;

    public void ShowToast<TComponent>() where TComponent : IComponent
    {
        toasts.Add(new InMemoryToast(typeof(TComponent)));
    }

    public void ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent
    {
        toasts.Add(new InMemoryToast(typeof(TComponent)));
    }

    public void ShowToast<TComponent>(ToastInstanceSettings settings) where TComponent : IComponent
    {
        toasts.Add(new InMemoryToast(typeof(TComponent)));
    }

    public void ShowToast<TComponent>(ToastParameters parameters, ToastInstanceSettings settings) where TComponent : IComponent
    {
        toasts.Add(new InMemoryToast(typeof(TComponent)));
    }

    public void ShowError(string message, string heading = "", Action onClick = null)
        => ShowToast(ToastLevel.Error, message, heading, onClick);

    public void ShowError(RenderFragment message, string heading = "", Action onClick = null)
        => ShowToast(ToastLevel.Error, message, heading, onClick);

    public void ShowInfo(string message, string heading = "", Action onClick = null)
        => ShowToast(ToastLevel.Info, message, heading, onClick);

    public void ShowInfo(RenderFragment message, string heading = "", Action onClick = null)
        => ShowToast(ToastLevel.Info, message, heading, onClick);

    public void ShowSuccess(string message, string heading = "", Action onClick = null)
        => ShowToast(ToastLevel.Success, message, heading, onClick);

    public void ShowSuccess(RenderFragment message, string heading = "", Action onClick = null)
        => ShowToast(ToastLevel.Success, message, heading, onClick);

    public void ShowToast(ToastLevel level, string message, string heading = "", Action onClick = null)
        => ShowToast(level, builder => builder.AddContent(0, message), heading, onClick);

    public void ShowToast(ToastLevel level, RenderFragment message, string heading = "", Action onClick = null)
        => toasts.Add(new InMemoryToast(typeof(Configuration.ToastInstance), level, message, GetHeading(level, heading)));

    public void ShowWarning(string message, string heading = "", Action onClick = null)
        => ShowToast(ToastLevel.Warning, message, heading, onClick);

    public void ShowWarning(RenderFragment message, string heading = "", Action onClick = null)
        => ShowToast(ToastLevel.Warning, message, heading, onClick);

    private string GetHeading(ToastLevel level, string heading)
    {
        if (!string.IsNullOrWhiteSpace(heading)) return heading;

        return level switch
        {
            ToastLevel.Error => "Error",
            ToastLevel.Info => "Info",
            ToastLevel.Success => "Success",
            ToastLevel.Warning => "Warning",
            _ => throw new InvalidOperationException(),
        };
    }

    public void ClearAll()
           => toasts.Clear();

    public void ClearToasts(ToastLevel toastLevel)
            => toasts.RemoveAll(x => x.ToastType == typeof(Configuration.ToastInstance) && x.ToastLevel == toastLevel);

    public void ClearWarningToasts()
            => toasts.RemoveAll(x => x.ToastType == typeof(Configuration.ToastInstance) && x.ToastLevel == ToastLevel.Warning);

    public void ClearInfoToasts()
            => toasts.RemoveAll(x => x.ToastType == typeof(Configuration.ToastInstance) && x.ToastLevel == ToastLevel.Info);

    public void ClearSuccessToasts()
            => toasts.RemoveAll(x => x.ToastType == typeof(Configuration.ToastInstance) && x.ToastLevel == ToastLevel.Success);

    public void ClearErrorToasts()
            => toasts.RemoveAll(x => x.ToastType == typeof(Configuration.ToastInstance) && x.ToastLevel == ToastLevel.Error);

    public void ClearCustomToasts()
            => toasts.RemoveAll(x => x.ToastType != typeof(Configuration.ToastInstance));
}
