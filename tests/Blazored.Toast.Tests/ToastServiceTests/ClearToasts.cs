using Blazored.Toast.Services;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ClearToasts
{
    private readonly ToastService _sut;

    public ClearToasts()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnClearToastsInnvoked_When_ClearToastsCalled()
    {
        // arrange
        var OnClearToastsCalled = false;
        _sut.OnClearToasts += (_) => OnClearToastsCalled = true;

        // act
        _sut.ClearToasts(ToastLevel.Warning);

        // assert
        Assert.True(OnClearToastsCalled);
    }

    [Fact]
    public void OnClearToastsContainsToastLevelWarning_When_ClearToastsCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnClearToasts += (argToastlevel) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ClearToasts(ToastLevel.Warning);

        // assert
        Assert.Equal(ToastLevel.Warning.ToString(), toastLevel);
    }
}
