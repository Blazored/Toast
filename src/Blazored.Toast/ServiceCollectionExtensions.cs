using System;
using Blazored.Toast.Services;
using Blazored.Toast.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Blazored.Toast
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazoredToast(this IServiceCollection services)
        {
            return AddBlazoredToast(services, new ToastOptions());
        }

        public static IServiceCollection AddBlazoredToast(this IServiceCollection services, Action<ToastOptions> toastOptionsAction)
        {
            if (toastOptionsAction == null) throw new ArgumentNullException(nameof(toastOptionsAction));

            var toastOptions = new ToastOptions();
            toastOptionsAction(toastOptions);

            return AddBlazoredToast(services, toastOptions);
        }
        public static IServiceCollection AddBlazoredToast(this IServiceCollection services, ToastOptions toastOptions)
        {
            if (toastOptions == null) throw new ArgumentNullException(nameof(toastOptions));

            services.TryAddScoped<IToastService>(builder => new ToastService(toastOptions));

            return services;
        }
    }
}
