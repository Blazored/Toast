using Blazored.Toast.Services;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests
{
    public class ClearErrorToasts
    {
        private readonly ToastService _sut;

        public ClearErrorToasts()
        {
            _sut = new ToastService();
        }

        [Fact]
        public void OnClearToastsInnvoked_When_ClearErrorToastsCalled()
        {
            // arrange
            var OnClearToastsCalled = false;
            _sut.OnClearToasts += (_) => OnClearToastsCalled = true;

            // act
            _sut.ClearErrorToasts();

            // assert
            Assert.True(OnClearToastsCalled);
        }

        [Fact]
        public void OnClearToastsContainsToastLevelWarning_When_ClearErrorToastsCalled()
        {
            // arrange
            var toastLevel = "";
            _sut.OnClearToasts += (argToastlevel) => toastLevel = argToastlevel.ToString();

            // act
            _sut.ClearErrorToasts();

            // assert
            Assert.Equal(ToastLevel.Error.ToString(), toastLevel);
        }
    }
}
