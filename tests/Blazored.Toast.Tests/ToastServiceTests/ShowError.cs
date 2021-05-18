using Blazored.Toast.Services;
using Bunit;
using Microsoft.AspNetCore.Components;
using System;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests
{
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
            var toastLevel = string.Empty;
            _sut.OnShow += (level, _, _, _) => toastLevel = level.ToString();

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
            var headingParameter = "heading";
            var heading = string.Empty;
            _sut.OnShow += (_, _, argHeading, _) => heading = argHeading;

            // act
            _sut.ShowError("message", headingParameter);

            // assert
            Assert.Equal("heading", headingParameter);
        }

        [Fact]
        public void OnShowEventContainsOnClickEvent_When_ShowErrorCalled()
        {
            // arrange
            var headingParameter = "heading";
            Action onClick = null;
            _sut.OnShow += (_, _, _, argOnClick) => onClick = argOnClick;

            // act
            _sut.ShowError("message", headingParameter, () => { });

            // assert
            Assert.NotNull(onClick);
        }

        [Fact]
        public void OnShowEventContainsMessage_When_ShowErrorCalledWithMessageRenderFragment()
        {
            // arrange
            RenderFragment message = null;
            _sut.OnShow += (_, argMessage, _, _) => message = argMessage;

            // act
            _sut.ShowError(builder => builder.AddContent(0, "message"));

            // assert
            Assert.NotNull(message);
        }
    }
}
