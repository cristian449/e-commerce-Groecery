using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FruitVegBasket.Services
{
    public class BaseApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseApiService(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }

        protected JsonSerializerOptions DefaultSerializerOptions = new() { PropertyNameCaseInsensitive = true };

        protected HttpClient HttpClient => _httpClientFactory.CreateClient(Constants.AppConstants.HttpClientName);

        protected TData Deserialize<TData>(string jsonData) =>
            JsonSerializer.Deserialize<TData>(jsonData, DefaultSerializerOptions);

        protected async Task<TData> HandleApiResponseAsync<TData>(HttpResponseMessage response, TData defaultValue)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(content))
                {
                    return JsonSerializer.Deserialize<TData>(content, DefaultSerializerOptions);
                }

            }
            return defaultValue;
        }
    }
}
