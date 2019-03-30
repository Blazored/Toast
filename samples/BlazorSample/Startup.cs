using Blazored.Toast;
using Blazored.Toast.Configuration;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSample
{
    public class Startup
    {
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredToast(options => {
                options.Timout = 10;
                options.Position = ToastPosition.BottomRight;
            });
        }
    }
}
