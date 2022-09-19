using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests;

public class ShowWarning
{
    private readonly ToastService _sut;

    public ShowWarning()
    {
        _sut = new ToastService();
    }

    [Fact]
    public void OnShowInvoked_When_ShowWarningCalled()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        // act
        _sut.ShowWarning("message");

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelWarning_When_ShowWarningCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ShowWarning("message");

        // assert
        Assert.Equal(ToastLevel.Warning.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowWarningCalled()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        // act
        _sut.ShowWarning("message");

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowInvoked_When_ShowWarningCalledWithRenderFragment()
    {
        // arrange
        var onShowCalled = false;
        _sut.OnShow += (_, _, _) => onShowCalled = true;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowWarning(messageFragment);

        // assert
        Assert.True(onShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelWarning_When_ShowWarningCalledWithRenderFragment()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _) => toastLevel = argToastlevel.ToString();

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowWarning(messageFragment);

        // assert
        Assert.Equal(ToastLevel.Warning.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowWarningCalledWithRenderFragment()
    {
        // arrange
        RenderFragment? message = null;
        _sut.OnShow += (_, argMessage, _) => message = argMessage;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowWarning(messageFragment);

        // assert
        Assert.NotNull(message);
    }
}
