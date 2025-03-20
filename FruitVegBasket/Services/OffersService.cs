using System.Text.Json;
using FruitVegBasket.Constants;
using FruitVegBasket.Models;

namespace FruitVegBasket.Services
{
    public class OffersService : BaseApiService
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        public OffersService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            //_httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
        {
            //var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);

            var response = await HttpClient.GetAsync("/masters/offers");
            return await HandleApiResponseAsync(response, Enumerable.Empty<Offer>());
            
        }
    }
}
