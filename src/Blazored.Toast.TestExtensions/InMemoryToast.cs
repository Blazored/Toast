using Blazored.Toast.Services;
using Bunit;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.TestExtensions
{
    public class InMemoryToast
    {
        private readonly ToastLevel _toastLevel;
        private readonly RenderFragment _message;
        private readonly string _heading;

        public InMemoryToast(ToastLevel toastLevel, RenderFragment message, string heading)
        {
            _toastLevel = toastLevel;
            _message = message;
            _heading = heading;
        }

        /// <summary>
        /// Checks toast element is rendered with level.
        /// </summary>
        /// <param name="level">The toast level expected.</param>
        public bool HasLevel(ToastLevel level)
            => _toastLevel == level;

        /// <summary>
        /// Checks toast element is rendered with message.
        /// </summary>
        /// <param name="message">The toast message expected.</param>
        public bool HasMessage(string message)
        {
            using var ctx = new TestContext();
            var cut = ctx.Render(_message);

            cut.MarkupMatches(message);
            return true;
        }

        /// <summary>
        /// Checks toast element is rendered with heading.
        /// </summary>
        /// <param name="heading">The toast heading expected.</param>
        public bool HasHeading(string heading)
            => _heading == heading;
    }
}
