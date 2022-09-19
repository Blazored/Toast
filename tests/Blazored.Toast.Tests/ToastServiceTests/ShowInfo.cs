using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ShowInfo
{
    private readonly ToastService _sut;

    public ShowInfo()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnShowInvoked_When_ShowInfoCalled()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowInfo("message");

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelInfo_When_ShowInfoCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ShowInfo("message");

        // assert
        Assert.Equal(ToastLevel.Info.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowInfoCalled()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        // act
        _sut.ShowInfo("message");

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowInvoked_When_ShowInfoCalledWithRenderFragment()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowInfo(messageFragment);

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelInfo_When_ShowInfoCalledWithRenderFragment()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowInfo(messageFragment);

        // assert
        Assert.Equal(ToastLevel.Info.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowInfoCalledWithRenderFragment()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowInfo(messageFragment);

        // assert
        Assert.NotNull(message);
    }
}
