using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.Components.Pages.Address.Components;
using AddressManagement.Blazor.ServiceManagers;
using AddressManagement.ClassLibrary.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace AddressManagement.Blazor.Components.Pages.Address
{
    public partial class CreateAddress : CommonBase
    {
        [Inject]
        public AddressServiceManager AddressServiceManager { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await AddressServiceManager.GetNewAddress();
        }

        private void SaveAddress(AddressViewModel address)
        {
            AddressServiceManager.UpdateAddress(address);
        }

        private void CancelSaveAddress()
        {
            NavigationManager.NavigateTo("/addresses");
        }

    }
}
