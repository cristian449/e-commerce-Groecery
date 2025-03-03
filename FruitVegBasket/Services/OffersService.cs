using System.Text.Json;
using FruitVegBasket.Constants;
using FruitVegBasket.Models;

namespace FruitVegBasket.Services
{
    public class OffersService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OffersService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);

            var response = await httpClient.GetAsync("/masters/offers");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(content))
                {
                    return JsonSerializer.Deserialize<IEnumerable<Offer>>(content);
                }
            }
            return Enumerable.Empty<Offer>();
        }
    }
}
