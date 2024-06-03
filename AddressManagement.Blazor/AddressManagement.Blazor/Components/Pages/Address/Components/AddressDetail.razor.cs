using AddressManagement.Blazor.BaseClasses;
using AddressManagement.Blazor.ServiceManagers;
using AddressManagement.ClassLibrary.ViewModels;
using Microsoft.AspNetCore.Components;

namespace AddressManagement.Blazor.Components.Pages.Address.Components
{
    public partial class AddressDetail : CommonBase, IDisposable
    {
        private AddressViewModel _address { get; set; } = new();
        [Parameter]
        public AddressServiceManager AddressServiceManager { get; set; }

        [Parameter]
        public Action<AddressViewModel> OnSaveAddress { get; set; }

        [Parameter]
        public Action OnCancelSaveAddress { get; set; }

        protected override void OnInitialized()
        {
            AddressServiceManager.AddressLoaded += OnAddressLoaded;
        }

        public void Dispose()
        {
            AddressServiceManager.AddressLoaded -= OnAddressLoaded;
        }


        private void OnAddressLoaded(AddressViewModel address)
        {
            _address = address;
            StateHasChanged();
        }


        private void HandleSaveClick()
        {
            OnSaveAddress?.Invoke(_address);
        }

        private void HandleCancelClick()
        {
            OnCancelSaveAddress?.Invoke();
        }
    }
}
