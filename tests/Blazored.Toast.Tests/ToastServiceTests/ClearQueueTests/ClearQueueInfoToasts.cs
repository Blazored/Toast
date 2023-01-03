using Blazored.Toast.Services;
using Blazored.Toast.Tests.ToastServiceTests.Base;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests.ClearQueueTests;

public class ClearQueueInfoToasts : BaseClearQueueTest
{
    protected override ToastLevel _toastLevel => ToastLevel.Info;

    protected Action _call;

    public ClearQueueInfoToasts() : base()
    {
        _call = _sut.ClearQueueInfoToasts;
    }

    [Fact]
    public void OnClearQueueToastsInvoked_When_ClearQueueInfoToastsCalled()
        => OnClearInvoked_When_ClearCalled(_eventAction, _call);

    [Fact]
    public void OnClearQueueToastsContainsToastLevelInfo_When_ClearQueueInfoToastsCalled()
        => OnClearToastsContainsToastLevel_When_ClearCalled(_eventAction, _call, _toastLevel);
}
