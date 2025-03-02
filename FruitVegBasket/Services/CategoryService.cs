using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitVegBasket.Models;

namespace FruitVegBasket.Services
{
    public class CategoryService
    {
        private IEnumerable<Category>? _categories;

        public async ValueTask<IEnumerable<Category>> GetCategoriesAsync()
        {
            if (_categories is not null)
                return _categories;
            {

                var categories = new List<Category>();

                var fruits = new List<Category>
                {
                    new (1, "Apple", 0, "apple.jpg", "Photo By <a href=\""),
                    new (2, "Banana", 0, "banana.jpg", "Photo By <a href=\""),
                };
                categories.AddRange(fruits);

                var vegetables = new List<Category>
                {
                    new (3, "Carrot", 0, "carrot.jpg", "Photo By <a href=\""),
                    new (4, "Broccoli", 0, "broccoli.jpg", "Photo By <a href=\""),
                };
                categories.AddRange(vegetables);

                var dairy = new List<Category>
                {
                    new (5, "Milk", 0, "milk.jpg", "Photo By <a href=\""),
                    new (6, "Cheese", 0, "cheese.jpg", "Photo By <a href=\""),
                };
                categories.AddRange(dairy);

                var eggsmeat = new List<Category>
                {
                    new (7, "Eggs", 0, "eggs.jpg", "Photo By <a href=\""),
                    new (8, "Chicken", 0, "chicken.jpg", "Photo By <a href=\""),
                };
                categories.AddRange(eggsmeat);

                _categories = categories;
            }


            return _categories;
        }
        
        public async ValueTask<IEnumerable<Category>> GetMainCategoriesAsync() =>
                        (await GetCategoriesAsync())
                        .Where(c => c.ParentId == 0);
    }
}
