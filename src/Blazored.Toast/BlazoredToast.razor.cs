using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast
{
    public class BlazoredToastBase : ComponentBase
    {
        [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; }

        [Parameter] protected Guid ToastId { get; set; }
        [Parameter] protected ToastSettings ToastSettings { get; set; }

        protected void Close()
        {
            ToastsContainer.RemoveToast(ToastId);
        }
    }
}
