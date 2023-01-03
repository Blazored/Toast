using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast;

public partial class BlazoredToast : IDisposable
{
    [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; } = default!;

    [Parameter, EditorRequired] public Guid ToastId { get; set; }
    [Parameter, EditorRequired] public ToastSettings Settings { get; set; } = default!;
    [Parameter] public ToastLevel? Level { get; set; }
    [Parameter] public RenderFragment? Message { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }

    private RenderFragment? CloseButtonContent => ToastsContainer.CloseButtonContent;

    private CountdownTimer? _countdownTimer;
    private int _progress = 100;

    protected override async Task OnInitializedAsync()
    {
        if (Settings.ShowProgressBar)
        {
            _countdownTimer = new CountdownTimer(Settings.Timeout)
                .OnTick(CalculateProgressAsync)
                .OnElapsed(Close);
        }
        else
        {
            _countdownTimer = new CountdownTimer(Settings.Timeout)
                .OnElapsed(Close);
        }

        await _countdownTimer.StartAsync();
    }

    /// <summary>
    /// Closes the toast
    /// </summary>
    public void Close()
        => ToastsContainer.RemoveToast(ToastId);

    private async Task CalculateProgressAsync(int percentComplete)
    {
        _progress = 100 - percentComplete;
        await InvokeAsync(StateHasChanged);
    }

    private void ToastClick()
        => Settings.OnClick?.Invoke();

    public void Dispose()
    {
        _countdownTimer?.Dispose();
        _countdownTimer = null;
    }
}