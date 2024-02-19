﻿using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.TestExtensions
{
    public class InMemoryToast
    {
        public Type ToastType { get; set; }
        public ToastLevel ToastLevel { get; }
        public RenderFragment? Message { get; }
        
        public ToastParameters? ToastParameters { get; }

        public InMemoryToast(Type toastType, ToastLevel toastLevel, RenderFragment message)
        {
            ToastType = toastType;
            ToastLevel = toastLevel;
            Message = message;
        }

        public InMemoryToast(Type toastType)
        {
            ToastType = toastType;
        }
        
        public InMemoryToast(Type toastType, ToastParameters toastParameters)
        {
            ToastType = toastType;
            ToastParameters = toastParameters;
        }
    }
}
