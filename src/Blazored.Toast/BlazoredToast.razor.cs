using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Toast
{
    public partial class BlazoredToast
    {
        [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; }

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public ToastSettings ToastSettings { get; set; }

        private void Close()
        {
            ToastsContainer.RemoveToast(ToastId);
        }
    }
}
