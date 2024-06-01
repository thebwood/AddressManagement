using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;
using AddressManagement.ClassLibrary.ViewModels;
using Microsoft.AspNetCore.Components;

namespace AddressManagement.Blazor.Components.Pages.Address.Components
{
    public partial class AddressGrid : CommonBase, IDisposable
    {
        private List<AddressViewModel> _addresses = new List<AddressViewModel>();
        [Parameter]
        public AddressServiceManager AddressServiceManager { get; set; }

        public AddressGrid()
        {
        }


        protected override void OnInitialized()
        {
            AddressServiceManager.AddressesLoaded += AddressesLoaded;
            AddressServiceManager.GetAddresses();
        }
        public void Dispose()
        {
            AddressServiceManager.AddressesLoaded -= AddressesLoaded;
        }


        private void AddressesLoaded(List<AddressViewModel> list)
        {
            _addresses = list;
        }

    }
}
