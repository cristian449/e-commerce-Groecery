using FruitVegBasket.ViewModels;

namespace FruitVegBasket.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel _viewmodel;
    public HomePage(HomePageViewModel viewModel)
    {
        _viewmodel = viewModel;
        BindingContext = _viewmodel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewmodel.InitializeAsync();
    }

    private void ProductsListControl_AddRemoveCartClicked(object sender, Controls.ProductCartItemChangeEventArgs e)
    {

        //This might be broken, as the viewmodel may not be correctly implemented
        if (e.Count > 0)

        {
            _viewmodel.AddToCartCommand.Execute(e.ProductId);
        }
        else
        {
            _viewmodel.RemoveFromCartCommand.Execute(e.ProductId);
        }
    }
}