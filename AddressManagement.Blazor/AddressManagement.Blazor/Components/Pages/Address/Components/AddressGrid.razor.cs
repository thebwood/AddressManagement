using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;
using AddressManagement.ClassLibrary.ViewModels;
using Microsoft.AspNetCore.Components;

namespace AddressManagement.Blazor.Components.Pages.Address.Components
{
    public partial class AddressGrid : CommonBase, IDisposable
    {
        private List<AddressViewModel> _addresses { get; set; } = new();
        [Parameter]
        public AddressServiceManager AddressServiceManager { get; set; }

        protected override void OnInitialized()
        {
            AddressServiceManager.AddressesLoaded += OnAddressesLoaded;
        }
        public void Dispose()
        {
            AddressServiceManager.AddressesLoaded -= OnAddressesLoaded;
        }

        private void OnAddressesLoaded(List<AddressViewModel> list)
        {
            _addresses = list;
            StateHasChanged();
        }



        public void EditAddress(Guid id)
        {
            NavigationManager.NavigateTo($"/addresses/{id}");
        }


        public void DeleteAddress(Guid id)
        {


        }
    }
}