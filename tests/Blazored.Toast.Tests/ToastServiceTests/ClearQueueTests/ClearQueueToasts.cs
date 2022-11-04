using Blazored.Toast.Services;
using Blazored.Toast.Tests.ToastServiceTests.Base;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests.ClearQueueTests;

public class ClearQueueToasts : BaseClearQueueTest
{
    protected override ToastLevel _toastLevel => ToastLevel.Warning;

    protected Action<ToastLevel> _call;

    public ClearQueueToasts() : base()
    {
        _call = _sut.ClearQueueToasts;
    }

    [Fact]
    public void OnClearQueueToastsInvoked_When_ClearQueueToastsCalled()
        => OnClearInvoked_When_ClearCalled(_eventAction, _call, _toastLevel);

    [Fact]
    public void OnClearQueueToastsContainsToastLevelWarning_When_ClearQueueToastsCalled()
        => OnClearToastsContainsToastLevel_When_ClearCalled(_eventAction, _call, _toastLevel);
}
