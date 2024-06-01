using AddressManagement.Blazor.Services.Interfaces;
using AddressManagement.ClassLibrary.DTOs;
using AddressManagement.ClassLibrary.ViewModels;

namespace AddressManagement.Blazor.ServiceManagers
{
    public class AddressServiceManager
    {
        private readonly IAddressService _addressService;


        public AddressServiceManager(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task GetAddresses()
        {
            GetAddressesResponseDTO response = await _addressService.GetAddresses();
            List<AddressViewModel> addressViewModels = response.AddressList.Select(a => new AddressViewModel
            {
                Id = a.Id,
                StreetAddress = a.StreetAddress,
                StreetAddress2 = a.StreetAddress2,
                City = a.City,
                State = a.State,
                PostalCode = a.PostalCode
            }).ToList();
            AddressesLoaded?.Invoke(addressViewModels);
        }

        public async Task GetAddress(Guid id)
        {
            GetAddressResponseDTO response = await _addressService.GetAddress(id);
            AddressLoaded?.Invoke(response.AddressDetail);
        }


        public Action<List<AddressViewModel>>? AddressesLoaded { get; set; }

        public Action<AddressViewModel>? AddressLoaded { get; set; }
    }
}
