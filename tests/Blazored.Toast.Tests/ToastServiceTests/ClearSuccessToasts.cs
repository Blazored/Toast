using Blazored.Toast.Services;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ClearSuccessToasts
{
    private readonly ToastService _sut;

    public ClearSuccessToasts()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnClearToastsInnvoked_When_ClearSuccessToastsCalled()
    {
        // arrange
        var OnClearToastsCalled = false;
        _sut.OnClearToasts += (_) => OnClearToastsCalled = true;

        // act
        _sut.ClearSuccessToasts();

        // assert
        Assert.True(OnClearToastsCalled);
    }

    [Fact]
    public void OnClearToastsContainsToastLevelWarning_When_ClearSuccessToastsCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnClearToasts += (argToastlevel) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ClearSuccessToasts();

        // assert
        Assert.Equal(ToastLevel.Success.ToString(), toastLevel);
    }
}
