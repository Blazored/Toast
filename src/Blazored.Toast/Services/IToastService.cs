using System;

namespace Blazored.Toast.Services
{
    public interface IToastService
    {
        event Action<ToastLevel, string, string> OnShow;

        void ShowToast(ToastLevel level, string message, string heading = "");
    }
}
