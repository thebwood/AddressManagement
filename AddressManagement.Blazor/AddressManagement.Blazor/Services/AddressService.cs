using AddressManagement.Blazor.Services.Interfaces;
using AddressManagement.ClassLibrary.Classes;
using AddressManagement.ClassLibrary.DTOs;
using System.Text;
using System.Text.Json;

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
        public Task<Result> DeleteAddress(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<GetAddressResponseDTO> GetAddress(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<GetAddressResponseDTO>($"api/addresses/{id}");
        }

        public async Task<GetAddressesResponseDTO> GetAddresses()
        {
            return await _httpClient.GetFromJsonAsync<GetAddressesResponseDTO>("api/Addresses");
        }

        public async Task<Result> AddAddress(AddAddressRequestDTO addressDTO)
        {
            Result result = new();

            string? json = JsonSerializer.Serialize(addressDTO);
            StringContent? content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpResponseMessage? httpResponseMessage = await _httpClient.PostAsync($"api/addresses", content);
            result.StatusCode = httpResponseMessage.StatusCode;
            result.Message = json;

            return result;
        }

        public async Task<Result> UpdateAddress(UpdateAddressRequestDTO addressDTO)
        {
            Result result = new();

            var json = JsonSerializer.Serialize(addressDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpResponseMessage? httpResponseMessage = await _httpClient.PutAsync($"addresses/{addressDTO.Address.Id}", content);
            result.StatusCode = httpResponseMessage.StatusCode;
            result.Message = json;

            return result;
        }
    }
}
