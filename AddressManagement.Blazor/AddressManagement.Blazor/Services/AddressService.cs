using AddressManagement.Blazor.Services.Interfaces;
using AddressManagement.ClassLibrary.Classes;
using AddressManagement.ClassLibrary.DTOs;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

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
            _httpClient.BaseAddress = new Uri("https://localhost:5001/");
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
        public async Task<GetAddressResponseDTO> GetAddress(Guid id) => await _httpClient.GetFromJsonAsync<GetAddressResponseDTO>($"api/addresses/{id}");

        public async Task<GetAddressesResponseDTO> GetAddresses()
        {
            return await _httpClient.GetFromJsonAsync<GetAddressesResponseDTO>("api/Addresses");
        }

        public Task<Result> UpdateAddress(UpdateAddressRequestDTO addressDTO)
        {
            throw new NotImplementedException();
        }
    }
}
