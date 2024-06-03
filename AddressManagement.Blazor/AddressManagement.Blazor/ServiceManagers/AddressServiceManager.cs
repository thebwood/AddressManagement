using AddressManagement.Blazor.Services.Interfaces;
using AddressManagement.ClassLibrary.Classes;
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
            var address = new AddressViewModel
            {
                Id = response.Address.Id,
                StreetAddress = response.Address.StreetAddress,
                StreetAddress2 = response.Address.StreetAddress2,
                City = response.Address.City,
                State = response.Address.State,
                PostalCode = response.Address.PostalCode
            };
            AddressLoaded?.Invoke(address);
        }


        public async Task CreateAddress(AddressViewModel address)
        {
            AddAddressRequestDTO request = new AddAddressRequestDTO
            {
                Address = new AddressDTO
                {
                    StreetAddress = address.StreetAddress,
                    StreetAddress2 = address.StreetAddress2,
                    City = address.City,
                    State = address.State,
                    PostalCode = address.PostalCode
                }
            };
            Result result = await _addressService.AddAddress(request);
        }

        public async Task UpdateAddress(AddressViewModel address)
        {
            UpdateAddressRequestDTO request = new UpdateAddressRequestDTO
            {
                Address = new AddressDTO
                {
                    Id = address.Id,
                    StreetAddress = address.StreetAddress,
                    StreetAddress2 = address.StreetAddress2,
                    City = address.City,
                    State = address.State,
                    PostalCode = address.PostalCode
                }
            };
            Result result = await _addressService.UpdateAddress(request);
        }

        public async Task GetNewAddress()
        {
            AddressViewModel address = new AddressViewModel();
            AddressLoaded?.Invoke(address);

        }

        public Action<List<AddressViewModel>>? AddressesLoaded { get; set; }

        public Action<AddressViewModel>? AddressLoaded { get; set; }
    }
}
