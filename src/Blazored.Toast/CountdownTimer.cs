using System;
using System.Timers;

namespace Blazored.Toast
{
    internal class CountdownTimer : IDisposable
    {
        private Timer _timer;
        private int _percentComplete;

        internal Action<int> OnTick;
        internal Action OnElapsed;

        internal CountdownTimer(int timeout)
        {
            _percentComplete = 0;
            _timer = new Timer()
            {
                Interval = timeout * 1000 / 100,
                AutoReset = true
            };

            _timer.Elapsed += HandleTick;
        }

        internal void Start()
        {
            _timer.Start();
        }

        private void HandleTick(object sender, ElapsedEventArgs args)
        {
            _percentComplete++;
            OnTick?.Invoke(_percentComplete);

            if (_percentComplete == 100)
            {
                _timer.Stop();
                OnElapsed?.Invoke();
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
            _timer = null;
        }
    }
}
