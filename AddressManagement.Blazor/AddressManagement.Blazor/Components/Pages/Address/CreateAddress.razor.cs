using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;
using Microsoft.AspNetCore.Components;

namespace AddressManagement.Blazor.Components.Pages.Address
{
    public partial class CreateAddress : CommonBase
    {
        [Inject]
        public AddressServiceManager AddressServiceManager { get; set; }


    }
}
