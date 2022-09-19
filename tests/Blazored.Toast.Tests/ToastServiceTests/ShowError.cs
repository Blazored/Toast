using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ShowError
{
    private readonly ToastService _sut;

    public ShowError()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnShowInvoked_When_ShowErrorCalled()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowError("message");

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelError_When_ShowErrorCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ShowError("message");

        // assert
        Assert.Equal(ToastLevel.Error.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowErrorCalled()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        // act
        _sut.ShowError("message");

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowInvoked_When_ShowErrorCalledWithRenderFragment()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowError(messageFragment);

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelError_When_ShowErrorCalledWithRenderFragment()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowError(messageFragment);

        // assert
        Assert.Equal(ToastLevel.Error.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowErrorCalledWithRenderFragment()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowError(messageFragment);

        // assert
        Assert.NotNull(message);
    }
}
