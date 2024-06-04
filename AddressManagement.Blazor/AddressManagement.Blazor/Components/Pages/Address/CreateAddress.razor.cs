using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;
using AddressManagement.ClassLibrary.ViewModels;
using Microsoft.AspNetCore.Components;

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
            AddressServiceManager.CreateAddress(address);
        }

        private void CancelSaveAddress()
        {
            NavigationManager.NavigateTo("/addresses");
        }

    }
}
