using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Threading.Tasks;

namespace Blazored.Toast.Tests.ToastServiceTests
{
    public class MyTestComponent : IComponent
    {
        private RenderHandle _renderHandle;

        public void Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);
            this.Render();
            return Task.CompletedTask;
        }

        public void Render()
            => _renderHandle.Render(RenderComponent);

        private void RenderComponent(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddContent(1, "My Test Toast Component");
            builder.CloseElement();
        }
    }
}
