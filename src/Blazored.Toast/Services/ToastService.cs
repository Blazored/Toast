using System;
using Blazored.Toast.Configuration;

namespace Blazored.Toast.Services
{
    public class ToastService : IToastService
    {
        public ToastOptions ToastOptions { get; private set; }

        public ToastService(ToastOptions toastOptions)
        {
            ToastOptions = toastOptions;
        }
        public event Action<ToastLevel, string, string> OnShow;

        public void ShowInfo(string message, string heading = "")
        {
            ShowToast(ToastLevel.Info, message, heading);
        }

        public void ShowSuccess(string message, string heading = "")
        {
            ShowToast(ToastLevel.Success, message, heading);
        }

        public void ShowWarning(string message, string heading = "")
        {
            ShowToast(ToastLevel.Warning, message, heading);
        }

        public void ShowError(string message, string heading = "")
        {
            ShowToast(ToastLevel.Error, message, heading);
        }

        public void ShowToast(ToastLevel level, string message, string heading = "")
        {
            OnShow?.Invoke(level, message, heading);
        }
    }
}
