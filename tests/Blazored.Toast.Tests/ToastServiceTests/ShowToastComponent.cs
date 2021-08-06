using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests
{
    public class ShowToastComponent
    {
        private readonly ToastService _sut;

        public ShowToastComponent()
        {
            _sut = new ToastService();
        }

        [Fact]
        public void OnShowComponentInvoked_When_ShowToastCalled()
        {
            // arrange
            var OnShowCalled = false;
            _sut.OnShowComponent += (_, _, _) => OnShowCalled = true;

            // act
            _sut.ShowToast<MyTestComponent>();

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowComponentEventContainsNoParameters_When_ShowToastCalled()
        {
            // arrange
            ToastParameters parameters = null;
            _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

            // act
            _sut.ShowToast<MyTestComponent>();

            // assert
            Assert.NotNull(parameters);
        }

        [Fact]
        public void OnShowComponentEventContainsNoSettings_When_ShowToastCalled()
        {
            // arrange
            ToastInstanceSettings settings = null;
            _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;

            // act
            _sut.ShowToast<MyTestComponent>();

            // assert
            Assert.Null(settings);
        }

        [Fact]
        public void OnShowComponentInvoked_When_ShowToastCalledWithParameters()
        {
            // arrange
            var OnShowCalled = false;
            _sut.OnShowComponent += (_, _, _) => OnShowCalled = true;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastParameters());

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowComponentEventContainsParameters_When_ShowToastCalledWithParameters()
        {
            // arrange
            ToastParameters parameters = null;
            _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastParameters());

            // assert
            Assert.NotNull(parameters);
        }

        [Fact]
        public void OnShowComponentEventContainsNoSettings_When_ShowToastCalledWithParameters()
        {
            // arrange
            ToastInstanceSettings settings = null;
            _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastParameters());

            // assert
            Assert.Null(settings);
        }

        [Fact]
        public void OnShowComponentInvoked_When_ShowToastCalledWithSettings()
        {
            // arrange
            var OnShowCalled = false;
            _sut.OnShowComponent += (_, _, _) => OnShowCalled = true;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastInstanceSettings(true));

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowComponentEventContainsNoParameters_When_ShowToastCalledWithSettings()
        {
            // arrange
            ToastParameters parameters = null;
            _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastInstanceSettings(true));

            // assert
            Assert.Null(parameters);
        }

        [Fact]
        public void OnShowComponentEventContainsSettings_When_ShowToastCalledWithSettings()
        {
            // arrange
            ToastInstanceSettings settings = null;
            _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastInstanceSettings(2, true));

            // assert
            Assert.NotNull(settings);
            Assert.Equal(2, settings.Timeout);
            Assert.True(settings.ShowProgressBar);
        }

        [Fact]
        public void OnShowComponentInvoked_When_ShowToastCalledWithParametersAndSettings()
        {
            // arrange
            var OnShowCalled = false;
            _sut.OnShowComponent += (_, _, _) => OnShowCalled = true;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastParameters(), new ToastInstanceSettings(true));

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowComponentEventContainsParameters_When_ShowToastCalledWithParametersAndSettings()
        {
            // arrange
            ToastParameters parameters = null;
            _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastParameters(), new ToastInstanceSettings(true));

            // assert
            Assert.NotNull(parameters);
        }

        [Fact]
        public void OnShowComponentEventContainsSettings_When_ShowToastCalledWithParametersAndSettings()
        {
            // arrange
            ToastInstanceSettings settings = null;
            _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;

            // act
            _sut.ShowToast<MyTestComponent>(new ToastParameters(), new ToastInstanceSettings(2, true));

            // assert
            Assert.NotNull(settings);
            Assert.Equal(2, settings.Timeout);
            Assert.True(settings.ShowProgressBar);
        }

        [Fact]
        public void ArgumentExceptionIsThrown_When_ShowToastCalledPassingIncorrectType()
        {
            // arrange / act
            Action action = () => _sut.ShowToast(typeof(int), null, null);

            // assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void OnShowComponentInvoked_When_ShowToastCalledWithCorrectTypeAndParametersAndSettings()
        {
            // arrange
            var OnShowCalled = false;
            _sut.OnShowComponent += (_, _, _) => OnShowCalled = true;

            // act
            _sut.ShowToast(typeof(IComponent), new ToastParameters(), new ToastInstanceSettings(true));

            // assert
            Assert.True(OnShowCalled);
        }

        [Fact]
        public void OnShowComponentEventContainsParameters_When_ShowToastCalledWithCorrectTypeAndParametersAndSettings()
        {
            // arrange
            ToastParameters parameters = null;
            _sut.OnShowComponent += (_, argParameters, _) => parameters = argParameters;

            // act
            _sut.ShowToast(typeof(IComponent), new ToastParameters(), new ToastInstanceSettings(true));

            // assert
            Assert.NotNull(parameters);
        }

        [Fact]
        public void OnShowComponentEventContainsSettings_When_ShowToastCalledWithCorrectTypeAndParametersAndSettings()
        {
            // arrange
            ToastInstanceSettings settings = null;
            _sut.OnShowComponent += (_, _, argSettings) => settings = argSettings;

            // act
            _sut.ShowToast(typeof(IComponent), new ToastParameters(), new ToastInstanceSettings(2, true));

            // assert
            Assert.NotNull(settings);
            Assert.Equal(2, settings.Timeout);
            Assert.True(settings.ShowProgressBar);
        }
    }
}
