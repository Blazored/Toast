using Blazored.Toast.Services;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests
{
    public class ClearCustomToasts
    {
        private readonly ToastService _sut;

        public ClearCustomToasts()
        {
            _sut = new ToastService();
        }

        [Fact]
        public void OnClearCustomToastsInnvoked_When_ClearCustomToastsCalled()
        {
            // arrange
            var OnClearCustomToastsCalled = false;
            _sut.OnClearCustomToasts += () => OnClearCustomToastsCalled = true;

            // act
            _sut.ClearCustomToasts();

            // assert
            Assert.True(OnClearCustomToastsCalled);
        }
    }
}
