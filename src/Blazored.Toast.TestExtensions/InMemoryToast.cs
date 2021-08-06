using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.TestExtensions
{
    public class InMemoryToast
    {
        public ToastLevel ToastLevel { get; }
        public RenderFragment Message { get; }
        public string Heading { get; }

        public InMemoryToast(ToastLevel toastLevel, RenderFragment message, string heading)
        {
            ToastLevel = toastLevel;
            Message = message;
            Heading = heading;
        }
    }
}
