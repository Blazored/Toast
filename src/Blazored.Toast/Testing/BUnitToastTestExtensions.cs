using AngleSharp.Dom;
using Blazored.Toast;
using Blazored.Toast.Services;
using Blazored.Toast.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Bunit
{
    [ExcludeFromCodeCoverage]
    public static class BUnitToastTestExtensions
    {
        private const string NullBlazoredToastsComponentExceptionMessage = "No BlazoredToasts component found. Enure AddBlazoredToast has been called in the test setup.";
        private const string NullBlazoredToastComponentExceptionMessage = "No BlazoredToast component provided.";
        public static IRenderedComponent<BlazoredToasts> AddBlazoredToast(this TestContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            context.Services
                .AddSingleton<IToastService, ToastService>();

            return context.RenderComponent<BlazoredToasts>();
        }

        /// <summary>
        /// Returns a readonly list of BlazoredToast components.
        /// </summary>
        public static IReadOnlyList<IRenderedComponent<BlazoredToast>> GetToasts(this IRenderedComponent<BlazoredToasts> blazoredToasts)
        {
            if (blazoredToasts is null)
                throw new ArgumentNullException(nameof(blazoredToasts), NullBlazoredToastsComponentExceptionMessage);

            return blazoredToasts.FindComponents<BlazoredToast>();
        }

        /// <summary>
        /// Checks a specific number of toast elements are rendered.
        /// </summary>
        /// <param name="count">The number of toast elements expected.</param>
        public static bool ToastCountIs(this IRenderedComponent<BlazoredToasts> blazoredToasts, int count)
        {
            if (blazoredToasts is null)
                throw new ArgumentNullException(nameof(blazoredToasts), NullBlazoredToastsComponentExceptionMessage);

            if (count < 1)
                throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} value must be greater than 0.");

            return blazoredToasts.GetToasts().Count == count;
        }

        /// <summary>
        /// Checks a single toast element is rendered.
        /// </summary>
        public static bool ToastCountIsOne(this IRenderedComponent<BlazoredToasts> blazoredToasts)
        {
            if (blazoredToasts is null)
                throw new ArgumentNullException(nameof(blazoredToasts), NullBlazoredToastsComponentExceptionMessage);

            return blazoredToasts.GetToasts().Count == 1;
        }

        /// <summary>
        /// Checks a single toast is rendered with level.
        /// </summary>
        /// <param name="level">The toast level expected.</param>
        public static bool ToastCountIsOneWithLevel(this IRenderedComponent<BlazoredToasts> blazoredToasts, ToastLevel level)
        {
            if (blazoredToasts is null)
                throw new ArgumentNullException(nameof(blazoredToasts), NullBlazoredToastsComponentExceptionMessage);

            var toasts = blazoredToasts.GetToasts();

            if (toasts.Count != 1)
                throw new ToastCountException(1, toasts.Count);

            return toasts.Single().ToastIsLevel(level);
        }

        /// <summary>
        /// Checks a single toast is rendered with heading.
        /// </summary>
        /// <param name="heading">The toast heading expected.</param>
        public static bool ToastCountIsOneWithHeading(this IRenderedComponent<BlazoredToasts> blazoredToasts, string heading)
        {
            if (blazoredToasts is null)
                throw new ArgumentNullException(nameof(blazoredToasts), NullBlazoredToastsComponentExceptionMessage);

            var toasts = blazoredToasts.GetToasts();

            if (toasts.Count != 1)
                throw new ToastCountException(1, toasts.Count);

            return toasts.Single().ToastHasHeading(heading);
        }

        /// <summary>
        /// Checks a single toast is rendered with message.
        /// </summary>
        /// <param name="message">The toast message expected.</param>
        public static bool ToastCountIsOneWithMessage(this IRenderedComponent<BlazoredToasts> blazoredToasts, string message)
        {
            if (blazoredToasts is null)
                throw new ArgumentNullException(nameof(blazoredToasts), NullBlazoredToastsComponentExceptionMessage);

            var toasts = blazoredToasts.GetToasts();

            if (toasts.Count != 1)
                throw new ToastCountException(1, toasts.Count);

            return toasts.Single().ToastHasMessage(message);
        }

        /// <summary>
        /// Checks no toast elements are rendered.
        /// </summary>
        public static bool ToastCountIsZero(this IRenderedComponent<BlazoredToasts> blazoredToasts)
        {
            if (blazoredToasts is null)
                throw new ArgumentNullException(nameof(blazoredToasts), NullBlazoredToastsComponentExceptionMessage);

            return blazoredToasts.GetToasts().Count == 0;
        }

        /// <summary>
        /// Checks toast element is rendered with heading.
        /// </summary>
        /// <param name="heading">The toast heading expected.</param>
        public static bool ToastHasHeading(this IRenderedComponent<BlazoredToast> toast, string heading)
        {
            if (toast is null)
                throw new ArgumentNullException(nameof(toast), NullBlazoredToastComponentExceptionMessage);

            var headingElement = toast.Find(".blazored-toast-heading");

            if (headingElement == null)
                return false;

            return headingElement.InnerHtml.Equals(heading);
        }

        /// <summary>
        /// Checks toast element is rendered with message.
        /// </summary>
        /// <param name="message">The toast message expected.</param>
        public static bool ToastHasMessage(this IRenderedComponent<BlazoredToast> toast, string message)
        {
            if (toast is null)
                throw new ArgumentNullException(nameof(toast), NullBlazoredToastComponentExceptionMessage);

            var messageElement = toast.Find(".blazored-toast-message");

            if (messageElement == null)
                return false;

            return messageElement.InnerHtml.Equals(message);
        }

        /// <summary>
        /// Checks toast element is rendered with level.
        /// </summary>
        /// <param name="level">The toast level expected.</param>
        public static bool ToastIsLevel(this IRenderedComponent<BlazoredToast> toast, ToastLevel level)
        {
            if (toast is null)
                throw new ArgumentNullException(nameof(toast), NullBlazoredToastComponentExceptionMessage);

            const string cssSelector = ".blazored-toast-container.blazored-toast-";

            IElement toastElement = null;
            try
            {
                switch (level)
                {
                    case ToastLevel.Info:
                        toastElement = toast.Find($"{cssSelector}info");
                        break;
                    case ToastLevel.Success:
                        toastElement = toast.Find($"{cssSelector}success");
                        break;
                    case ToastLevel.Warning:
                        toastElement = toast.Find($"{cssSelector}warning");
                        break;
                    case ToastLevel.Error:
                        toastElement = toast.Find($"{cssSelector}error");
                        break;
                    default:
                        break;
                }
            }
            catch (ElementNotFoundException)
            {
                return false;
            }

            return toastElement != null;
        }
    }
}
