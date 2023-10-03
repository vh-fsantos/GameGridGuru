using AutoMapper;
using CommunityToolkit.Maui;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.Services.Services;
using GameGridGuru.Infraestructure;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Infraestructure.Repositories;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Mapping;
using GameGridGuru.UI.Services;
using GameGridGuru.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<PostgresDbContext>();
        builder.Services.AddTransient<IPopupService, PopupService>();
        builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
        builder.Services.AddTransient<IProductRepository, ProductRepository>();
        builder.Services.AddTransient<ICustomerService, CustomerService>();
        
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        var mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
        
        return builder.Build();
    }
}