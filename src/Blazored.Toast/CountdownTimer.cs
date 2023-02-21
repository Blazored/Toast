namespace Blazored.Toast;
internal class CountdownTimer : IDisposable
{
    private PeriodicTimer _timer;
    private readonly int _ticksToTimeout;
    private readonly CancellationToken _cancellationToken;
    private readonly int _extendedTimeout;
    private int _percentComplete;
    private bool _isPaused;
    private Func<int, Task>? _tickDelegate;
    private Action? _elapsedDelegate;
    internal CountdownTimer(int timeout, int extendedTimeout = 0, CancellationToken cancellationToken = default)
    {
        _ticksToTimeout = 100;
        _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(timeout * 10));
        _cancellationToken = cancellationToken;
        _extendedTimeout = extendedTimeout;
    }

    internal CountdownTimer OnTick(Func<int, Task> updateProgressDelegate)
    {
        _tickDelegate = updateProgressDelegate;
        return this;
    }

    internal CountdownTimer OnElapsed(Action elapsedDelegate)
    {
        _elapsedDelegate = elapsedDelegate;
        return this;
    }

    internal async Task StartAsync()
    {
        _percentComplete = 0;
        await DoWorkAsync();
    }

    internal void Pause()
    {
        _isPaused = true;
    }

    internal async Task UnPause()
    {
        _isPaused = false;
        if (_extendedTimeout > 0)
        {
            _timer?.Dispose();
            _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(_extendedTimeout * 10));
            await StartAsync();
        }
    }

    private async Task DoWorkAsync()
    {
        while (await _timer.WaitForNextTickAsync(_cancellationToken) && !_cancellationToken.IsCancellationRequested)
        {
            if (!_isPaused)
            {
                _percentComplete++;
            }

            if (_tickDelegate != null)
            {
                await _tickDelegate(_percentComplete);
            }

            if (_percentComplete == _ticksToTimeout)
            {
                _elapsedDelegate?.Invoke();
            }
        }
    }

    public void Dispose() => _timer.Dispose();
}
