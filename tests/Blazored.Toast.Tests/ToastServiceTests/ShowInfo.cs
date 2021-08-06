using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests
{
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
            var OnShowCalled = false;
            _sut.OnShow += (_, _, _, _) => OnShowCalled = true;

            // act
            _sut.ShowInfo("message");

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowEventContainsToastLevelInfo_When_ShowInfoCalled()
        {
            // arrange
            var toastLevel = "";
            _sut.OnShow += (argToastlevel, _, _, _) => toastLevel = argToastlevel.ToString();

            // act
            _sut.ShowInfo("message");

            // assert
            Assert.Equal(ToastLevel.Info.ToString(), toastLevel);
        }

        [Fact]
        public void OnShowEventContainsMessage_When_ShowInfoCalled()
        {
            // arrange
            RenderFragment message = null;
            _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

            // act
            _sut.ShowInfo("message");

            // assert
            Assert.NotNull(message);
        }

        [Fact]
        public void OnShowEventContainsHeading_When_ShowInfoCalled()
        {
            // arrange
            var heading = string.Empty;
            _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

            // act
            _sut.ShowInfo("message", "heading");

            // assert
            Assert.NotEmpty(heading);
        }

        [Fact]
        public void OnShowEventContainsOnClickAction_When_ShowInfoCalled()
        {
            // arrange
            Action onClick = null;
            _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

            // act
            _sut.ShowInfo("message", string.Empty, () => { });

            // assert
            Assert.NotNull(onClick);
        }

        [Fact]
        public void OnShowInvoked_When_ShowInfoCalledWithRenderFragment()
        {
            // arrange
            var OnShowCalled = false;
            _sut.OnShow += (_, _, _, _) => OnShowCalled = true;

            var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

            // act
            _sut.ShowInfo(messageFragment);

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowEventContainsToastLevelInfo_When_ShowInfoCalledWithRenderFragment()
        {
            // arrange
            var toastLevel = "";
            _sut.OnShow += (argToastlevel, _, _, _) => toastLevel = argToastlevel.ToString();

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
            RenderFragment message = null;
            _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

            var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

            // act
            _sut.ShowInfo(messageFragment);

            // assert
            Assert.NotNull(message);
        }

        [Fact]
        public void OnShowEventContainsHeading_When_ShowInfoCalledWithRenderFragment()
        {
            // arrange
            var heading = string.Empty;
            _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

            var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

            // act
            _sut.ShowInfo(messageFragment, "heading");

            // assert
            Assert.NotEmpty(heading);
        }

        [Fact]
        public void OnShowEventContainsOnClickAction_When_ShowInfoCalledWithRenderFragment()
        {
            // arrange
            Action onClick = null;
            _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

            var messageFragment = new RenderFragment(_ => _.AddContent(0, "message"));

            // act
            _sut.ShowInfo(messageFragment, string.Empty, () => { });

            // assert
            Assert.NotNull(onClick);
        }
    }
}
