using Blazored.Toast.Services;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests
{
    public class ClearCustomComponentToasts
    {
        private readonly ToastService _sut;

        public ClearCustomComponentToasts()
        {
            _sut = new ToastService();
        }

        [Fact]
        public void OnClearCustomComponentToastsInnvoked_When_ClearCustomComponentToastsCalled()
        {
            // arrange
            var OnClearCustomComponentToastsCalled = false;
            _sut.OnClearCustomComponentToasts += () => OnClearCustomComponentToastsCalled = true;

            // act
            _sut.ClearCustomComponentToasts();

            // assert
            Assert.True(OnClearCustomComponentToastsCalled);
        }
    }
}
