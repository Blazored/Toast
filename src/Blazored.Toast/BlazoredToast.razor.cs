using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast;

public partial class BlazoredToast : IDisposable
{
    [CascadingParameter]
    private BlazoredToasts? ToastsContainer { get; set; }

    [Parameter]
    public Guid ToastId { get; set; }

    [Parameter]
    public ToastSettings? ToastSettings { get; set; }

    [Parameter]
    public ToastInstanceSettings? ToastComponentSettings { get; set; }

    [Parameter]
    public int Timeout { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private RenderFragment? CloseButtonContent => ToastsContainer?.CloseButtonContent;
    private bool ShowCloseButton => ToastsContainer?.ShowCloseButton ?? false;

    private CountdownTimer? _countdownTimer;
    private int _progress = 100;


    protected override void OnInitialized()
    {
        _countdownTimer = new CountdownTimer(Timeout)
            .OnTick(CalculateProgressAsync)
            .OnElapsed(Close);

        _countdownTimer.Start();
    }

    private async Task CalculateProgressAsync(int percentComplete)
    {
        _progress = 100 - percentComplete;
        await InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Closes the toast
    /// </summary>
    public void Close() => ToastsContainer?.RemoveToast(ToastId);

    private void ToastClick() => ToastSettings?.OnClick?.Invoke();

    public void Dispose()
    {
        _countdownTimer?.Dispose();
        _countdownTimer = null;
    }
}
