using System;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast
{
    internal class CountdownTimer : IDisposable
    {
        private Timer _timer;
        private int _timeout;
        private int _countdownTotal;
        private int _percentComplete;

        internal Action<int> OnTick;
        internal Action OnElapsed;

        internal CountdownTimer(int timeout)
        {
            _countdownTotal = timeout;
            _timeout = (_countdownTotal * 1000) / 100;
            _percentComplete = 0;
            SetupTimer();
        }

        internal void Start()
        {
            _timer.Start();
        }

        private void SetupTimer()
        {
            _timer = new Timer(_timeout);
            _timer.Elapsed += HandleTick;
            _timer.AutoReset = false;
        }

        private void HandleTick(object sender, ElapsedEventArgs args)
        {
            _percentComplete++;
            OnTick?.Invoke(_percentComplete);

            if (_percentComplete == 100)
            {
                OnElapsed?.Invoke();
            }
            else
            {
                SetupTimer();
                Start();
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
            _timer = null;
        }
    }
}
