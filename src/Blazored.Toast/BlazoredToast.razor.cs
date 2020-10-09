using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Blazored.Toast
{
    public partial class BlazoredToast : IDisposable
    {
        [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; }

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public ToastSettings ToastSettings { get; set; }
        [Parameter] public int Timeout { get; set; }
        [Parameter] public EventCallback<CloseEventArgs> OnClose { get; set; }

        private CountdownTimer _countdownTimer;
        private int _progress = 100;

        protected override void OnInitialized()
        {
            _countdownTimer = new CountdownTimer(Timeout);
            _countdownTimer.OnTick += CalculateProgress;
            _countdownTimer.OnElapsed += async () => { await Close(new CloseEventArgs() {Toast = this, AutoClose = true}); };
            _countdownTimer.Start();
        }

        private async void CalculateProgress(int percentComplete)
        {
            _progress = 100 - percentComplete;
            await InvokeAsync(StateHasChanged);
        }

        private async Task Close(CloseEventArgs e)
        {
            if (e != null && OnClose.HasDelegate)
            {
                await OnClose.InvokeAsync(e);
            }
            ToastsContainer.RemoveToast(ToastId);
        }

        public void Dispose()
        {
            _countdownTimer.Dispose();
            _countdownTimer = null;
        }
    }
}
