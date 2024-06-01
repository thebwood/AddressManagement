using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;
using Microsoft.AspNetCore.Components;

namespace AddressManagement.Blazor.Components.Pages.Address
{
    public partial class Addresses : CommonBase
    {
        [Inject]

        public AddressServiceManager _addressServiceManager { get; set; }
        protected override async void OnInitialized()
        {
            await _addressServiceManager.GetAddresses();
        }


    }
}
