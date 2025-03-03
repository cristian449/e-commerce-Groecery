using CommunityToolkit.Maui;
using FruitVegBasket.Interfaces;
using FruitVegBasket.Pages;
using FruitVegBasket.Services;
using FruitVegBasket.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Devices;

namespace FruitVegBasket
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

            builder.Services.AddSingleton<IplatformHttpMessageHandler>(sp =>
            {
#if ANDROID
                    return new Platforms.Android.AndroidHttpMessageHandler();
#elif IOS
                return new Platforms.iOS.IosHttpMessageHandler();
#else
                    throw new PlatformNotSupportedException("Platform not supported");
#endif
            });

            //This might be very broken, unsure if it will work this was in part 6 of the grocery app
            //video 21:38 is the part where this was done

            builder.Services.AddHttpClient(Constants.AppConstants.HttpClientName, httpClient =>
            {
                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                                                                 ? "https://10.0.2.2:5503"
                                                                 : "https://localhost:5503";
                httpClient.BaseAddress = new Uri(baseAddress);
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                var platformHttpMessageHandler = builder.Services.BuildServiceProvider().GetRequiredService<IplatformHttpMessageHandler>();
                return platformHttpMessageHandler.GetHttpMessageHandler();
            });

            //This might be very broken, unsure if it will work this was in part 6 of the grocery app
            //video 21:38 is the part where this was done

            builder.Services.AddHttpClient(Constants.AppConstants.HttpClientName, httpClient =>
            {
                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                                                         ? "https://10.0.2.2:5503"
                                                         : "https://localhost:5503";
                httpClient.BaseAddress = new Uri(baseAddress);
            })
            .ConfigureHttpMessageHandlerBuilder(configBuilder =>
            {
                var platformHttpMessageHandler = configBuilder.Services.GetRequiredService<IplatformHttpMessageHandler>();
                configBuilder.PrimaryHandler = platformHttpMessageHandler.GetHttpMessageHandler();
            });

            builder.Services.AddSingleton<CategoryService>();
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<HomePage>();

            builder.Services.AddTransient<OffersService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
