namespace Blazored.Toast.Configuration {
    public class ToastOptions
    {
        /// <summary>
        /// <para>Time in seconds toasts will show before being removed.</para>
        /// Default: 5 seconds.
        /// </summary>
        public int Timeout { get; set; } = 5;

        /// <summary>
        /// <para>The position on the screen toasts will appear.</para>
        /// Default: Top Right.
        /// </summary>
        public ToastPosition Position { get; set; } = ToastPosition.TopRight;
    }
}