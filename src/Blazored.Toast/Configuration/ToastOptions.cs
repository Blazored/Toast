namespace Blazored.Toast.Configuration {
    public class ToastOptions {
        public int Timeout { get; set; } = 5;
        public ToastPosition Position { get; set; } = ToastPosition.TopRight;
    }
}