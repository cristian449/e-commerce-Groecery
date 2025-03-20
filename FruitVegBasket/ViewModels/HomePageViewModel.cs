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
        private readonly OffersService _offersService;

        public HomePageViewModel(CategoryService categoryService, OffersService offersService)
        {
            _categoryService = categoryService;
            _offersService = offersService;
        }

        public ObservableCollection<Category> Categories { get; set; } = new();

        public ObservableCollection<Offer> Offers { get; set; } = new();

        [ObservableProperty]
        private bool _isBusy = true;

        public async Task InitializeAsync()
        {
            try
            {
                var offersTask = _offersService.GetActiveOffersAsync();
                foreach (var category in await _categoryService.GetMainCategoriesAsync())
                {
                    Categories.Add(category);
                }
                foreach (var offer in await offersTask)
                {
                    Offers.Add(offer);
                }
            }
            finally
            {
                _isBusy = false; //Might be incorrect, somehow have to use regular Isbusy = false instead of _isbusy = false 
                                 //Apparently supposed to generate property for IsBusy, but I dont know how to do that or it doesnt work

            }


        }


    }
}
