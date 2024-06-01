using AddressManagement.Blazor.Services.Interfaces;
using AddressManagement.ClassLibrary.Classes;
using AddressManagement.ClassLibrary.DTOs;
using Microsoft.Extensions.Configuration;

namespace AddressManagement.Blazor.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;
        public IConfiguration _configuration { get; }


        public AddressService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["AddressApiUrl"]);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public Task<Result> AddAddress(AddAddressRequestDTO addressDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAddress(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GetAddressResponseDTO> GetAddress(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GetAddressesResponseDTO> GetAddresses()
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAddress(UpdateAddressRequestDTO addressDTO)
        {
            throw new NotImplementedException();
        }
    }
}
