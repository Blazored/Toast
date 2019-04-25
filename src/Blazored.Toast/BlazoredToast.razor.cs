using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast
{
    public class BlazoredToastBase : ComponentBase
    {
        [Parameter] protected Guid ToastId { get; set; }
        [Parameter] protected ToastSettings ToastSettings { get; set; }
        [Parameter] protected ToastOptions ToastOptions { get; set; }
        [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; }

        protected void Close()
        {
            ToastsContainer.RemoveToast(ToastId);
        }
    }
}
