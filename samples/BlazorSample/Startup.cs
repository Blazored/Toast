using Blazored.Toast;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSample
{
    public class Startup
    {
        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredToast();
        }
    }
}
