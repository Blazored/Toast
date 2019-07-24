using Blazored.Toast;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorClientSideSample
{
    public class Startup
    {
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredToast();
        }
    }
}
