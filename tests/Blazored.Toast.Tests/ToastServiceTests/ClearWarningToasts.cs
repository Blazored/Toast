using Blazored.Toast.Services;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ClearWarningToasts
{
    private readonly ToastService _sut;

    public ClearWarningToasts()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnClearToastsInnvoked_When_ClearWarningToastsCalled()
    {
        // arrange
        var OnClearToastsCalled = false;
        _sut.OnClearToasts += (_) => OnClearToastsCalled = true;

        // act
        _sut.ClearWarningToasts();

        // assert
        Assert.True(OnClearToastsCalled);
    }

    [Fact]
    public void OnClearToastsContainsToastLevelWarning_When_ClearWarningToastsCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnClearToasts += (argToastlevel) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ClearWarningToasts();

        // assert
        Assert.Equal(ToastLevel.Warning.ToString(), toastLevel);
    }
}
