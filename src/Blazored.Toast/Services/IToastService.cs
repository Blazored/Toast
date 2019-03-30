using System;
using Blazored.Toast.Configuration;

namespace Blazored.Toast.Services
{
    public interface IToastService
    {
        ToastOptions ToastOptions { get; }
        event Action<ToastLevel, string, string> OnShow;

        void ShowInfo(string message, string heading = "");
        void ShowSuccess(string message, string heading = "");
        void ShowWarning(string message, string heading = "");
        void ShowError(string message, string heading = "");
        void ShowToast(ToastLevel level, string message, string heading = "");
    }
}
