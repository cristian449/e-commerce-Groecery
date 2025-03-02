using FruitVegBasket.ViewModels;

namespace FruitVegBasket.Pages;

public partial class HomePage : ContentPage
{
	private readonly HomePageViewModel _viewmodel;
    public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		_viewmodel = viewModel;
        BindingContext = _viewmodel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewmodel.InitializeAsync();
    }
}