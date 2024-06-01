using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AddressManagement.Blazor.BaseClasses
{
    public class CommonBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

    }
}