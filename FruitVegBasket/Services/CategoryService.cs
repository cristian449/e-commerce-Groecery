using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FruitVegBasket.Constants;
using FruitVegBasket.Models;

namespace FruitVegBasket.Services
{


    public class CategoryService : BaseApiService
    {
        

        public CategoryService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            //_httpClientFactory = httpClientFactory;

        }


        private IEnumerable<Category>? _categories;
        //private readonly IHttpClientFactory _httpClientFactory;

        public async ValueTask<IEnumerable<Category>> GetCategoriesAsync()
        {
            if (_categories is null)
            { 

                //var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);

                var response = await HttpClient.GetAsync("/masters/categories");

                var categories = await HandleApiResponseAsync<IEnumerable<Category>>(response, null);
                
                if (categories is null)
                    return Enumerable.Empty<Category>();

               
                _categories = categories;
            }


            return _categories;
        }
        
        public async ValueTask<IEnumerable<Category>> GetMainCategoriesAsync() =>
                        (await GetCategoriesAsync())
                        .Where(c => c.ParentId == 0);
    }
}
