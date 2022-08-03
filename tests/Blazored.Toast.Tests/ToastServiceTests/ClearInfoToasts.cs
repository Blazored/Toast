using Blazored.Toast.Services;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ClearInfoToasts
{
    private readonly ToastService _sut;

    public ClearInfoToasts()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnClearToastsInnvoked_When_ClearInfoToastsCalled()
    {
        // arrange
        var OnClearToastsCalled = false;
        _sut.OnClearToasts += (_) => OnClearToastsCalled = true;

        // act
        _sut.ClearInfoToasts();

        // assert
        Assert.True(OnClearToastsCalled);
    }

    [Fact]
    public void OnClearToastsContainsToastLevelWarning_When_ClearInfoToastsCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnClearToasts += (argToastlevel) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ClearInfoToasts();

        // assert
        Assert.Equal(ToastLevel.Info.ToString(), toastLevel);
    }
}
