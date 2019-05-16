using Blazored.Toast.Services;

namespace BlazorServerSideSample.Services
{
    public class ServiceA
    {
        private readonly IToastService _toastService;

        public ServiceA(IToastService toastService)
        {
            _toastService = toastService;
        }
        public void ShowMessage()
        {
            _toastService.ShowSuccess("I'm a SUCCESS message with a custom title", "Congratulations!");
        }
    }
}
