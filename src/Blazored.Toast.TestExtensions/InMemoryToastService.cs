using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazored.Toast.TestExtensions
{
    public class InMemoryToastService : IToastService
    {
        public IList<InMemoryToast> Toasts = new List<InMemoryToast>();

        public event Action<ToastLevel, RenderFragment, string, Action> OnShow;

        public void ShowError(string message, string heading = "", Action onClick = null)
            => ShowToast(ToastLevel.Error, message, heading, onClick);

        public void ShowError(RenderFragment message, string heading = "", Action onClick = null)
            => ShowToast(ToastLevel.Error, message, heading, onClick);

        public void ShowInfo(string message, string heading = "", Action onClick = null)
            => ShowToast(ToastLevel.Info, message, heading, onClick);

        public void ShowInfo(RenderFragment message, string heading = "", Action onClick = null)
            => ShowToast(ToastLevel.Info, message, heading, onClick);

        public void ShowSuccess(string message, string heading = "", Action onClick = null)
            => ShowToast(ToastLevel.Success, message, heading, onClick);

        public void ShowSuccess(RenderFragment message, string heading = "", Action onClick = null)
            => ShowToast(ToastLevel.Success, message, heading, onClick);

        public void ShowToast(ToastLevel level, string message, string heading = "", Action onClick = null)
            => ShowToast(level, builder => builder.AddContent(0, message), heading, onClick);

        public void ShowToast(ToastLevel level, RenderFragment message, string heading = "", Action onClick = null)
            => Toasts.Add(new InMemoryToast(level, message, GetHeading(level, heading)));

        public void ShowWarning(string message, string heading = "", Action onClick = null)
            => ShowToast(ToastLevel.Warning, message, heading, onClick);

        public void ShowWarning(RenderFragment message, string heading = "", Action onClick = null)
            => ShowToast(ToastLevel.Warning, message, heading, onClick);

        private string GetHeading(ToastLevel level, string heading)
        {
            if (!string.IsNullOrWhiteSpace(heading)) return heading;

            return level switch
            {
                ToastLevel.Error => "Error",
                ToastLevel.Info => "Info",
                ToastLevel.Success => "Success",
                ToastLevel.Warning => "Warning",
                _ => throw new InvalidOperationException(),
            };
        }
        /// <summary>
        /// Checks a specific number of toasts are displayed.
        /// </summary>
        /// <param name="count">The number of toast elements expected.</param>
        public bool ToastCountIs(int count)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} value must be greater than 0.");

            return Toasts.Count == count;
        }

        /// <summary>
        /// Checks a single toast is displayed.
        /// </summary>
        public bool ToastCountIsOne()
            => Toasts.Count == 1;

        /// <summary>
        /// Checks a single toast is displayed with level.
        /// </summary>
        /// <param name="level">The toast level expected.</param>
        public bool ToastCountIsOneWithLevel(ToastLevel level)
        {
            if (Toasts.Count != 1)
                throw new ToastCountException(1, Toasts.Count);

            return Toasts.Single().HasLevel(level);
        }

        /// <summary>
        /// Checks a single toast is displayed with heading.
        /// </summary>
        /// <param name="heading">The toast heading expected.</param>
        public bool ToastCountIsOneWithHeading(string heading)
        {
            if (Toasts.Count != 1)
                throw new ToastCountException(1, Toasts.Count);

            return Toasts.Single().HasHeading(heading);
        }

        /// <summary>
        /// Checks a single toast is displayed with message.
        /// </summary>
        /// <param name="message">The toast message expected.</param>
        public bool ToastCountIsOneWithMessage(string message)
        {
            if (Toasts.Count != 1)
                throw new ToastCountException(1, Toasts.Count);

            return Toasts.Single().HasMessage(message);
        }

        /// <summary>
        /// Checks no toast elements are displayed.
        /// </summary>
        public bool ToastCountIsZero()
            => Toasts.Count == 0;
    }
}
