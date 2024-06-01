using AddressManagement.Blazor.Services.Interfaces;
using AddressManagement.Blazor.Services;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using AddressManagement.Blazor.ServiceManagers;

namespace AddressManagement.Blazor.DependencyInjection
{
    public static class PresentationDependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, string baseAddress)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

            AsyncRetryPolicy<HttpResponseMessage> retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            services.AddHttpClient<IAddressService, AddressService>()
                .AddPolicyHandler(retryPolicy);


            services.AddScoped<AddressServiceManager>();
            return services;
        }
    }
}