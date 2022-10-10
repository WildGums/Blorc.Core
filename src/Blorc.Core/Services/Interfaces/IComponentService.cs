namespace Blorc.Services
{
    using Microsoft.AspNetCore.Components;

    public interface IComponentService
    {
        ComponentBase? Component { get; set; }
    }
}
