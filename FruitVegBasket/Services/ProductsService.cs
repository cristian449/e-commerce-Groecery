using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitVegBasket.Models;
using FruitVegBasket.Shared.Dtos;

namespace FruitVegBasket.Services
{
    public class ProductsService : BaseApiService
    {
       public ProductsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IEnumerable<ProductDto>> GetPopularProductsAsync()
        {
            

            var response = await HttpClient.GetAsync("/popular-products");
            return await HandleApiResponseAsync(response, Enumerable.Empty<ProductDto>());

        }
    }
}
