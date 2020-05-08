using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;
using System;
using System.Timers;

namespace Blazored.Toast
{
    public partial class BlazoredToast : IDisposable
    {
        [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; }

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public ToastSettings ToastSettings { get; set; }
        [Parameter] public int Timeout { get; set; }

        private Timer _timer;

        protected override void OnInitialized()
        {
            _timer = new Timer(Timeout * 1000);
            _timer.Elapsed += (sender, args) => { Close(); };
            _timer.AutoReset = false;
            _timer.Start();
        }

        private void Close()
        {
            ToastsContainer.RemoveToast(ToastId);
        }

        public void Dispose()
        {
            _timer.Dispose();
            _timer = null;
        }
    }
}
