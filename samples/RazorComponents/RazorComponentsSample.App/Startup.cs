using Blazored.Toast;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using RazorComponentsSample.App.Services;

namespace RazorComponentsSample.App
{
    public class Startup
    {
        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service to read the forecast data.
            services.AddSingleton<WeatherForecastService>();
            services.AddBlazoredToast();
        }
    }
}
