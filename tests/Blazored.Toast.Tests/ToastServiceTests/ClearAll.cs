using Blazored.Toast.Services;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests
{
    public class ClearAll
    {
        private readonly ToastService _sut;

        public ClearAll()
        {
            _sut = new ToastService();
        }

        [Fact]
        public void OnClearAllInvoked_When_ClearAllCalled()
        {
            // arrange
            var OnClearAllCalled = false;
            _sut.OnClearAll += () => OnClearAllCalled = true;

            // act
            _sut.ClearAll();

            // assert
            Assert.True(OnClearAllCalled);
        }
    }
}
