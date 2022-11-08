using Blazored.Toast.Services;
using Blazored.Toast.Tests.ToastServiceTests.Base;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests.ClearQueueTests;

public class ClearQueueSuccessToasts : BaseClearQueueTest
{
    protected override ToastLevel _toastLevel => ToastLevel.Success;

    protected Action _call;

    public ClearQueueSuccessToasts() : base()
    {
        _call = _sut.ClearQueueSuccessToasts;
    }

    [Fact]
    public void OnClearQueueToastsInvoked_When_ClearQueueSuccessToastsCalled()
        => OnClearInvoked_When_ClearCalled(_eventAction, _call);

    [Fact]
    public void OnClearQueueToastsContainsToastLevelSuccess_When_ClearQueueSuccessToastsCalled()
        => OnClearToastsContainsToastLevel_When_ClearCalled(_eventAction, _call, _toastLevel);
}
