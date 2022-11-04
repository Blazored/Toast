using Blazored.Toast.Services;
using Blazored.Toast.Tests.ToastServiceTests.Base;
using Xunit;

namespace Blazored.Toast.Tests.ToastServiceTests.ClearQueueTests
{
    public class ClearQueue : BaseClearTest
    {
        public ClearQueue() : base()
        {
        }

        [Fact]
        public void OnClearQueueInvoked_When_ClearQueueCalled()
            => OnClearInvoked_When_ClearCalled(x => _sut.OnClearQueue += x, _sut.ClearQueue);
    }
}
