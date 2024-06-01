using AddressManagement.ClassLibrary.Classes;
using AddressManagement.ClassLibrary.DTOs;

namespace AddressManagement.Blazor.Services.Interfaces
{
    public interface IAddressService
    {

        Task<GetAddressesResponseDTO> GetAddresses();
        Task<GetAddressResponseDTO> GetAddress(Guid id);

        Task<Result> AddAddress(AddAddressRequestDTO addressDTO);

        Task<Result> UpdateAddress(UpdateAddressRequestDTO addressDTO);
        Task<Result> DeleteAddress(Guid id);
    }
}
