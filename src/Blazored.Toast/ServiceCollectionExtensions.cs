using Blazored.Toast.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blazored.Toast;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazoredToast(this IServiceCollection services)
    {
        return services.AddScoped<IToastService, ToastService>();
    }
}
