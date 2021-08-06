using Blazored.Toast;
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
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.Equal(1, toastService.Toasts.Count);
        }

        [Fact]
        public void DisplaysZeroToasts()
        {
            // Arrange Act
            var toastService = this.AddBlazoredToast();
            RenderComponent<Index>();

            // Assert
            Assert.Equal(0, toastService.Toasts.Count);
        }

        [Fact]
        public void DisplaysTwoToasts()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Index>();

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
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.Equal(ToastLevel.Info, toastService.Toasts.Single().ToastLevel);
        }

        [Fact]
        public void DisplaysToastWithHeading()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Equal("Congratulations!", toastService.Toasts.Single().Heading);
        }

        [Fact]
        public void DisplaysTwoToastsWithLevel()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(toastService.Toasts,
                _ => Assert.Equal(ToastLevel.Info, _.ToastLevel),
                _ => Assert.Equal(ToastLevel.Success, _.ToastLevel));
        }

        [Fact]
        public void DisplaysTwoToastsWithHeading()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(toastService.Toasts,
                _ => Assert.Equal("Info", _.Heading),
                _ => Assert.Equal("Congratulations!", _.Heading));
        }

        [Fact]
        public void DisplaysToasts()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<Index>();

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
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("#ComponentButton").Click();

            // Assert
            Assert.Equal(1, toastService.Toasts.Count(_ => _.ToastType == typeof(MyToastComponent)));
        }
    }
}
