using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FruitVegBasket.Models;
using FruitVegBasket.Shared.Dtos;

namespace FruitVegBasket.ViewModels
{
    
public partial class CartViewModel : ObservableObject
    {
        public ObservableCollection<CartItem> CartItems { get; set; } = new();

        [ObservableProperty]
        private int _count; //The number of products we have in the cart (Not the quantities of those products)

        [ObservableProperty]
        private decimal _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = CartItems.Sum(c => c.Amount);

        private void IncreaseCartItemQuantity(Guid cartItemId)
        {
            var item = CartItems.FirstOrDefault(c => c.Id == cartItemId);
            if(item is not null)
            {
                item.Quantity++;
            }
        }

        //This might be a workaround however i am unsure if this is the correct way to do it, it says that mvvm is automatically
        //Supposed to implement Count as a property but it is not working for me



        //Had to change Everything from Private to Public as it otherwise did not work, maybe will look into it later
        //Video was part 11 dont remember the timestamp

        [RelayCommand]
        public void AddToCart(ProductDto product)
        {
            var item = CartItems.FirstOrDefault(c => c.ProductId == product.Id);
            if (item is not null)
            {
                item.Quantity++;
                RecalculateTotalAmount();
            }
            else
            {
                item = new CartItem
                {
                    Id = Guid.NewGuid(),
                    ProductName = product.Name,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price,
                };
                CartItems.Add(item);
                Count = CartItems.Count;
            }
            RecalculateTotalAmount();
        }

        [RelayCommand]
        public void RemoveFromCart(int productId)
        {
            var item = CartItems.FirstOrDefault(c => c.ProductId == productId);
            if (item is not null)
            {
                if (item.Quantity == 1)
                {
                    CartItems.Remove(item);
                    Count = CartItems.Count;
                }
                else
                {
                    item.Quantity--;
                }
                
            }
            RecalculateTotalAmount();
        }

        public void ClearCart()
        {
            CartItems.Clear();
            Count = 0;
            RecalculateTotalAmount();
        }

        
        
    }
}

