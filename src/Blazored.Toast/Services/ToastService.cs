using System;

namespace Blazored.Toast.Services
{
    public class ToastService : IToastService
    {
        public event Action<ToastLevel, string, string> OnShow;

        public void ShowToast(ToastLevel level, string message, string heading = "")
        {
            OnShow?.Invoke(level, message, heading);
        }
    }
}
