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
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.True(blazoredToasts.ToastCountIsOne());
        }

        [Fact]
        public void DisplaysZeroToasts()
        {
            // Arrange Act
            var blazoredToasts = this.AddBlazoredToast();
            RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Assert
            Assert.True(blazoredToasts.ToastCountIsZero());
        }

        [Fact]
        public void DisplaysTwoToasts()
        {
            // Arrange
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            var button = cut.Find("#InfoButton");
            button.Click();
            button.Click();

            // Assert
            Assert.True(blazoredToasts.ToastCountIs(2));
        }

        [Fact]
        public void DisplaysToastWithLevel()
        {
            // Arrange
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.True(blazoredToasts.ToastCountIsOneWithLevel(ToastLevel.Info));
        }

        [Fact]
        public void DisplaysToastWithMessage()
        {
            // Arrange
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();

            // Assert
            Assert.True(blazoredToasts.ToastCountIsOneWithMessage("I'm an INFO message"));
        }

        [Fact]
        public void DisplaysToastWithHeading()
        {
            // Arrange
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.True(blazoredToasts.ToastCountIsOneWithHeading("Congratulations!"));
        }

        [Fact]
        public void DisplaysTwoToastsWithLevel()
        {
            // Arrange
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(blazoredToasts.GetToasts(),
                _ => Assert.True(_.ToastIsLevel(ToastLevel.Info)),
                _ => Assert.True(_.ToastIsLevel(ToastLevel.Success)));
        }

        [Fact]
        public void DisplaysTwoToastsWithMessages()
        {
            // Arrange
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(blazoredToasts.GetToasts(),
                _ => Assert.True(_.ToastHasMessage("I'm an INFO message")),
                _ => Assert.True(_.ToastHasMessage("I'm a SUCCESS message with a custom heading")));
        }

        [Fact]
        public void DisplaysTwoToastsWithHeading()
        {
            // Arrange
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.Collection(blazoredToasts.GetToasts(),
                _ => Assert.True(_.ToastHasHeading("Info")),
                _ => Assert.True(_.ToastHasHeading("Congratulations!")));
        }

        [Fact]
        public void DisplaysToasts()
        {
            // Arrange
            var blazoredToasts = this.AddBlazoredToast();
            var cut = RenderComponent<BlazorWebAssembly.Pages.Index>();

            // Act
            cut.Find("#InfoButton").Click();
            cut.Find("#SuccessButton").Click();

            // Assert
            Assert.NotEmpty(blazoredToasts.GetToasts());
        }

    }
}
