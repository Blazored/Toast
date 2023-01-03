using Blazored.Toast.Services;
using Blazored.Toast.Tests.ToastServiceTests.Base;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests.ClearQueueTests;

public class ClearQueueErrorToasts : BaseClearQueueTest
{
    protected override ToastLevel _toastLevel => ToastLevel.Error;

    protected Action _call;

    public ClearQueueErrorToasts() : base()
    {
        _call = _sut.ClearQueueErrorToasts;
    }

    [Fact]
    public void OnClearQueueToastsInvoked_When_ClearQueueErrorToastsCalled()
        => OnClearInvoked_When_ClearCalled(_eventAction, _call);

    [Fact]
    public void OnClearQueueToastsContainsToastLevelError_When_ClearQueueErrorToastsCalled()
        => OnClearToastsContainsToastLevel_When_ClearCalled(_eventAction, _call, _toastLevel);
}
