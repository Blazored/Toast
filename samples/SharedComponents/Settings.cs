using System;
using Blazored.Toast.Configuration;

namespace SharedComponents
{
    public class Settings
    {
        public ToastPosition Position { get; set; } = ToastPosition.BottomRight;
        public int TimeoutSeconds { get; set; } = 10;
        public bool ShowProgressBar { get; set; }
        public TimeSpan? CloseDelay { get; set; }
        public string CustomCssClass { get; set; }
    }
}
