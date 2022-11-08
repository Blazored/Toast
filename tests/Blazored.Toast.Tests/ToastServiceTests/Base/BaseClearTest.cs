using Blazored.Toast.Services;
using System.Reflection.Metadata;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests.Base
{
    public abstract class BaseClearTest
    {
        protected readonly ToastService _sut;

        protected BaseClearTest()
        {
            _sut = new ToastService();
        }

        #region OnClearInvoked
        protected void OnClearInvoked_When_ClearCalled(Action<Action?> eventAction, Action call)
        {
            // arrange
            var onClearCalled = false;
            eventAction(() => onClearCalled = true);

            // act
            call();

            // assert
            Assert.True(onClearCalled);
        }

        protected void OnClearInvoked_When_ClearCalled(Action<Action<ToastLevel>?> eventAction, Action call)
        {
            // arrange
            var onClearCalled = false;
            eventAction((_) => onClearCalled = true);

            // act
            call();

            // assert
            Assert.True(onClearCalled);
        }

        protected void OnClearInvoked_When_ClearCalled(Action<Action<ToastLevel>?> eventAction, Action<ToastLevel> call, ToastLevel level)
        {
            // arrange
            var onClearCalled = false;
            eventAction((_) => onClearCalled = true);

            // act
            call(level);

            // assert
            Assert.True(onClearCalled);
        }
        #endregion

        #region 
        protected void OnClearToastsContainsToastLevel_When_ClearCalled(Action<Action<ToastLevel>?> eventAction, Action call, ToastLevel level)
        {
            // arrange
            var toastLevel = "";

            eventAction((argToastlevel) => toastLevel = argToastlevel.ToString());

            // act
            call();

            // assert
            Assert.Equal(level.ToString(), toastLevel);
        }

        protected void OnClearToastsContainsToastLevel_When_ClearCalled(Action<Action<ToastLevel>?> eventAction, Action<ToastLevel> call, ToastLevel level)
            => OnClearToastsContainsToastLevel_When_ClearCalled(eventAction, () => call(level), level);
        #endregion
    }
}
