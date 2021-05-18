using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests
{
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
            var OnShowCalled = false;
            _sut.OnShow += (_, _, _, _) => OnShowCalled = true;

            // act
            _sut.ShowSuccess("message");

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowEventContainsToastLevelSuccess_When_ShowSuccessCalled()
        {
            // arrange
            var toastLevel = "";
            _sut.OnShow += (argToastlevel, _, _, _) => toastLevel = argToastlevel.ToString();

            // act
            _sut.ShowSuccess("message");

            // assert
            Assert.Equal(ToastLevel.Success.ToString(), toastLevel);
        }

        [Fact]
        public void OnShowEventContainsMessage_When_ShowSuccessCalled()
        {
            // arrange
            RenderFragment message = null;
            _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

            // act
            _sut.ShowSuccess("message");

            // assert
            Assert.NotNull(message);
        }

        [Fact]
        public void OnShowEventContainsHeading_When_ShowSuccessCalled()
        {
            // arrange
            var heading = string.Empty;
            _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

            // act
            _sut.ShowSuccess("message", "heading");

            // assert
            Assert.NotEmpty(heading);
        }

        [Fact]
        public void OnShowEventContainsOnClickAction_When_ShowSuccessCalled()
        {
            // arrange
            Action onClick = null;
            _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

            // act
            _sut.ShowSuccess("message", string.Empty, () => { });

            // assert
            Assert.NotNull(onClick);
        }

        [Fact]
        public void OnShowInvoked_When_ShowSuccessCalledWithRenderFragment()
        {
            // arrange
            var OnShowCalled = false;
            _sut.OnShow += (_, _, _, _) => OnShowCalled = true;

            var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

            // act
            _sut.ShowSuccess(messageFragment);

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowEventContainsToastLevelSuccess_When_ShowSuccessCalledWithRenderFragment()
        {
            // arrange
            var toastLevel = "";
            _sut.OnShow += (argToastlevel, _, _, _) => toastLevel = argToastlevel.ToString();

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
            RenderFragment message = null;
            _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

            var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

            // act
            _sut.ShowSuccess(messageFragment);

            // assert
            Assert.NotNull(message);
        }

        [Fact]
        public void OnShowEventContainsHeading_When_ShowSuccessCalledWithRenderFragment()
        {
            // arrange
            var heading = string.Empty;
            _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

            var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

            // act
            _sut.ShowSuccess(messageFragment, "heading");

            // assert
            Assert.NotEmpty(heading);
        }

        [Fact]
        public void OnShowEventContainsOnClickAction_When_ShowSuccessCalledWithRenderFragment()
        {
            // arrange
            Action onClick = null;
            _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

            var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

            // act
            _sut.ShowSuccess(messageFragment, string.Empty, () => { });

            // assert
            Assert.NotNull(onClick);
        }
    }
}
