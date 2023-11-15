using CommunityToolkit.Maui;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.Services.Services;
using GameGridGuru.Infraestructure;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Infraestructure.Repositories;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Services;
using GameGridGuru.UI.ViewModels;

namespace GameGridGuru.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<PostgresDbContext>();
        builder.Services.AddTransient<IPopupService, PopupService>();
        builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
        builder.Services.AddTransient<IProductRepository, ProductRepository>();
        builder.Services.AddTransient<ICustomerService, CustomerService>();
        
        return builder.Build();
    }
}