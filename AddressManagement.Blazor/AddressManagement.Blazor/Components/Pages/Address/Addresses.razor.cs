using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;
using Microsoft.AspNetCore.Components;

namespace AddressManagement.Blazor.Components.Pages.Address
{
    public partial class Addresses : CommonBase
    {
        [Inject]
        public AddressServiceManager AddressServiceManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AddressServiceManager.GetAddresses();
        }
    }
}
