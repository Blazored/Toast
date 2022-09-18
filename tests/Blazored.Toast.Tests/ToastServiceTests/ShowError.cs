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
        var OnShowCalled = false;
        _sut.OnShow += (_, _, _, _) => OnShowCalled = true;

        // act
        _sut.ShowError("message");

        // assert
        Assert.True(OnShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelError_When_ShowErrorCalled()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _, _) => toastLevel = argToastlevel.ToString();

        // act
        _sut.ShowError("message");

        // assert
        Assert.Equal(ToastLevel.Error.ToString(), toastLevel);
    }

    [Fact]
    public void OnShowEventContainsMessage_When_ShowErrorCalled()
    {
        // arrange
        RenderFragment message = null;
        _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

        // act
        _sut.ShowError("message");

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowEventContainsHeading_When_ShowErrorCalled()
    {
        // arrange
        var heading = string.Empty;
        _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

        // act
        _sut.ShowError("message", "heading");

        // assert
        Assert.NotEmpty(heading);
    }

    [Fact]
    public void OnShowEventContainsOnClickAction_When_ShowErrorCalled()
    {
        // arrange
        Action onClick = null;
        _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

        // act
        _sut.ShowError("message", string.Empty, () => { });

        // assert
        Assert.NotNull(onClick);
    }

    [Fact]
    public void OnShowInvoked_When_ShowErrorCalledWithRenderFragment()
    {
        // arrange
        var OnShowCalled = false;
        _sut.OnShow += (_, _, _, _) => OnShowCalled = true;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowError(messageFragment);

        // assert
        Assert.True(OnShowCalled);
    }

    [Fact]
    public void OnShowEventContainsToastLevelError_When_ShowErrorCalledWithRenderFragment()
    {
        // arrange
        var toastLevel = "";
        _sut.OnShow += (argToastlevel, _, _, _) => toastLevel = argToastlevel.ToString();

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
        RenderFragment message = null;
        _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowError(messageFragment);

        // assert
        Assert.NotNull(message);
    }

    [Fact]
    public void OnShowEventContainsHeading_When_ShowErrorCalledWithRenderFragment()
    {
        // arrange
        var heading = string.Empty;
        _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowError(messageFragment, "heading");

        // assert
        Assert.NotEmpty(heading);
    }

    [Fact]
    public void OnShowEventContainsOnClickAction_When_ShowErrorCalledWithRenderFragment()
    {
        // arrange
        Action onClick = null;
        _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

        var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

        // act
        _sut.ShowError(messageFragment, string.Empty, () => { });

        // assert
        Assert.NotNull(onClick);
    }
}
