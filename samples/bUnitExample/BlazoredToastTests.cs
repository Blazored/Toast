using Blazored.Toast.Services;
using BlazorWebAssembly.Pages;
using Bunit;
using System.Linq;
using Xunit;

namespace bUnitExample
{
    public class BlazoredToastTests : TestContext
    {
        [Fact]
        public void DisplaysToast()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Home>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.Single(toastService.Toasts);
        }

        [Fact]
        public void DisplaysZeroToasts()
        {
            // Arrange Act
            var toastService = this.AddBlazoredToast();
            RenderComponent<Home>();

            // Assert
            Assert.Empty(toastService.Toasts);
        }

        [Fact]
        public void DisplaysTwoToasts()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Home>();

            // Act
            var button = cut.Find("#InfoButton");
            button.Click();
            button.Click();

            // Assert
            Assert.Equal(2, toastService.Toasts.Count);
        }

        [Fact]
        public void DisplaysToastWithLevel()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Home>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.Equal(ToastLevel.Info, toastService.Toasts.Single().ToastLevel);
        }

        [Fact]
        public void DisplaysTwoToastsWithLevel()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Home>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(toastService.Toasts,
                toastLevel => Assert.Equal(ToastLevel.Info, toastLevel.ToastLevel),
                toastLevel => Assert.Equal(ToastLevel.Success, toastLevel.ToastLevel));
        }

        [Fact]
        public void DisplaysToasts()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Home>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.NotEmpty(toastService.Toasts);
        }

        [Fact]
        public void DisplaysToastComponent()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Home>();

            // Act
            cut.Find("#CustomButton").Click();

            // Assert
            Assert.Equal(1, toastService.Toasts.Count(toast => toast.ToastType == typeof(MyToastComponent)));
        }
        
        [Fact]
        public void DisplaysToastComponentWithLevel()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Home>();

            // Act
            cut.Find("#CustomButton").Click();

            // Assert
            Assert.Equal(ToastLevel.Info, toastService.Toasts.Single().ToastParameters!.TryGet<ToastLevel>(nameof(MyToastComponent.Status)));
        }
    }
}
