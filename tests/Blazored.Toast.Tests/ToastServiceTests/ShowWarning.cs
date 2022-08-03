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
        var OnShowCalled = false;
        _sut.OnShow += (_, _, _, _) => OnShowCalled = true;

        // act
        _sut.ShowWarning("message");

        // assert
        Assert.True(OnShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelWarning_When_ShowWarningCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _, _) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ShowWarning("message");

        // assert
        Assert.Equal(ToastLevel.Warning.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowWarningCalled()
    {
        // arrange
        RenderFragment message = null;
        _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

        // act
        _sut.ShowWarning("message");

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowEventContainsHeading_When_ShowWarningCalled()
    {
        // arrange
        var heading = string.Empty;
        _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

        // act
        _sut.ShowWarning("message", "heading");

        // assert
        Assert.NotEmpty(heading);
    }

    [Fact]
    public void OnShowEventContainsOnClickAction_When_ShowWarningCalled()
    {
        // arrange
        Action onClick = null;
        _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

        // act
        _sut.ShowWarning("message", string.Empty, () => { });

        // assert
        Assert.NotNull(onClick);
    }

    [Fact]
    public void OnShowInvoked_When_ShowWarningCalledWithRenderFragment()
    {
        // arrange
        var OnShowCalled = false;
        _sut.OnShow += (_, _, _, _) => OnShowCalled = true;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowWarning(messageFragment);

        // assert
        Assert.True(OnShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelWarning_When_ShowWarningCalledWithRenderFragment()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _, _) => toastLevel = argToastlevel.ToString();

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
        RenderFragment message = null;
        _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowWarning(messageFragment);

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowEventContainsHeading_When_ShowWarningCalledWithRenderFragment()
    {
        // arrange
        var heading = string.Empty;
        _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowWarning(messageFragment, "heading");

        // assert
        Assert.NotEmpty(heading);
    }

    [Fact]
    public void OnShowEventContainsOnClickAction_When_ShowWarningCalledWithRenderFragment()
    {
        // arrange
        Action onClick = null;
        _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowWarning(messageFragment, string.Empty, () => { });

        // assert
        Assert.NotNull(onClick);
    }
}
