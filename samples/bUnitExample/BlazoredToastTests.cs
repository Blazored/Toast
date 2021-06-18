using Blazored.Toast;
using Blazored.Toast.Services;
using Bunit;
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
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.True(toastService.ToastCountIsOne());
        }

        [Fact]
        public void DisplaysZeroToasts()
        {
            // Arrange Act
            var toastService = this.AddBlazoredToast();
            RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Assert
            Assert.True(toastService.ToastCountIsZero());
        }

        [Fact]
        public void DisplaysTwoToasts()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            var button = cut.Find("#InfoButton");
            button.Click();
            button.Click();

            // Assert
            Assert.True(toastService.ToastCountIs(2));
        }

        [Fact]
        public void DisplaysToastWithLevel()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.True(toastService.ToastCountIsOneWithLevel(ToastLevel.Info));
        }

        [Fact]
        public void DisplaysToastWithMessage()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.True(toastService.ToastCountIsOneWithMessage("I'm an INFO message"));
        }

        [Fact]
        public void DisplaysToastWithHeading()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.True(toastService.ToastCountIsOneWithHeading("Congratulations!"));
        }

        [Fact]
        public void DisplaysTwoToastsWithLevel()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(toastService.Toasts,
                _ => Assert.True(_.HasLevel(ToastLevel.Info)),
                _ => Assert.True(_.HasLevel(ToastLevel.Success)));
        }

        [Fact]
        public void DisplaysTwoToastsWithMessages()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(toastService.Toasts,
                _ => Assert.True(_.HasMessage("I'm an INFO message")),
                _ => Assert.True(_.HasMessage("I'm a SUCCESS message with a custom heading")));
        }

        [Fact]
        public void DisplaysTwoToastsWithHeading()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(toastService.Toasts,
                _ => Assert.True(_.HasHeading("Info")),
                _ => Assert.True(_.HasHeading("Congratulations!")));
        }

        [Fact]
        public void DisplaysToasts()
        {
            // Arrange
            var toastService = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.NotEmpty(toastService.Toasts);
        }
    }
}
