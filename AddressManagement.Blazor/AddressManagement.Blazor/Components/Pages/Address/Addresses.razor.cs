using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;

namespace AddressManagement.Blazor.Components.Pages.Address
{
    public partial class Addresses : CommonBase
    {
        public AddressServiceManager _addressServiceManager { get; set; }

        public Addresses(AddressServiceManager addressServiceManager) 
        { 
            _addressServiceManager = addressServiceManager;
        }

    }
}
