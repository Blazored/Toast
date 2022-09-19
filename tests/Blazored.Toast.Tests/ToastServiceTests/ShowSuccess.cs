using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ShowSuccess
{
    private readonly ToastService _sut;

    public ShowSuccess()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnShowInvoked_When_ShowSuccessCalled()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowSuccess("message");

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelSuccess_When_ShowSuccessCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ShowSuccess("message");

        // assert
        Assert.Equal(ToastLevel.Success.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowSuccessCalled()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        // act
        _sut.ShowSuccess("message");

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowInvoked_When_ShowSuccessCalledWithRenderFragment()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowSuccess(messageFragment);

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelSuccess_When_ShowSuccessCalledWithRenderFragment()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowSuccess(messageFragment);

        // assert
        Assert.Equal(ToastLevel.Success.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowSuccessCalledWithRenderFragment()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowSuccess(messageFragment);

        // assert
        Assert.NotNull(message);
    }
}
