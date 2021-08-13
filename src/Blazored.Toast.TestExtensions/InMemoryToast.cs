using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast.TestExtensions
{
    public class InMemoryToast
    {
        public Type ToastType { get; set; }
        public ToastLevel ToastLevel { get; }
        public RenderFragment Message { get; }
        public string Heading { get; }

        public InMemoryToast(Type toastType, ToastLevel toastLevel, RenderFragment message, string heading)
        {
            ToastType = toastType;
            ToastLevel = toastLevel;
            Message = message;
            Heading = heading;
        }

        public InMemoryToast(Type toastType)
        {
            ToastType = toastType;
        }
    }
}
