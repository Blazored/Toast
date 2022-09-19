using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ShowToast
{
    private readonly ToastService _sut;

    public ShowToast()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnShowInvoked_When_ShowToastCalled()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowToast(ToastLevel.Info, "message");

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelInfo_When_ShowToastCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ShowToast(ToastLevel.Info, "message");

        // assert
        Assert.Equal(ToastLevel.Info.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowToastCalled()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        // act
        _sut.ShowToast(ToastLevel.Info, "message");

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowInvoked_When_ShowToastCalledWithRenderFragment()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowToast(ToastLevel.Info, messageFragment);

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelInfo_When_ShowToastCalledWithRenderFragment()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowToast(ToastLevel.Info, messageFragment);

        // assert
        Assert.Equal(ToastLevel.Info.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowToastCalledWithRenderFragment()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowToast(ToastLevel.Info, messageFragment);

        // assert
        Assert.NotNull(message);
    }
}
