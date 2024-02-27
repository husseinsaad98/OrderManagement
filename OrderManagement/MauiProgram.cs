using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using OrderManagement.Models;
using OrderManagement.Services;
using OrderManagement.ViewModels;
using OrderManagement.Views.Account;
using OrderManagement.Views.Order;

namespace OrderManagement
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<AccountService>();
            builder.Services.AddSingleton<ItemService>();
            builder.Services.AddSingleton<OrderService>();
            builder.Services.AddSingleton<ClientService>();

            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddTransient<Orders>();
            builder.Services.AddTransient<OrdersViewModel>();

            builder.Services.AddTransient<ManageOrder>();
            builder.Services.AddTransient<ManageOrderViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
