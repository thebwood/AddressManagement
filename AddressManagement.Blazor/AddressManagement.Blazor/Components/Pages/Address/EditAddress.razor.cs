using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;
using AddressManagement.ClassLibrary.ViewModels;
using Microsoft.AspNetCore.Components;

namespace AddressManagement.Blazor.Components.Pages.Address
{
    public partial class EditAddress : CommonBase
    {
        [Inject]
        public AddressServiceManager AddressServiceManager { get; set; }

        [Parameter]
        public Guid AddressId { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await AddressServiceManager.GetAddress(AddressId);
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
