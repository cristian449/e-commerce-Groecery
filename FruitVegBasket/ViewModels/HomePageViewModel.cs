using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using FruitVegBasket.Models;
using FruitVegBasket.Services;

namespace FruitVegBasket.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;

        public HomePageViewModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ObservableCollection<Category> Categories { get; set; } = new();

        public async Task InitializeAsync()
        {
             foreach (var category in await _categoryService.GetMainCategoriesAsync())
            {
                Categories.Add(category);
            }

        }


    }
}
