using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast
{
    public class BlazoredToastBase : ComponentBase
    {
        [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; }

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public ToastSettings ToastSettings { get; set; }

        protected void Close()
        {
            ToastsContainer.RemoveToast(ToastId);
        }
    }
}
