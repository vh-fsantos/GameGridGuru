using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.Infraestructure.Repositories;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.Services.Services;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Services;
using GameGridGuru.UI.ViewModels;

namespace GameGridGuru.UI.DependencyInjection;

public static class InjectServices
{
    public static void InjectUi(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
        services.AddSingleton<MainViewModel>();
    }
    
    public static void InjectRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICourtRepository, CourtRepository>();
    }
    
    public static void InjectApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IPopupService, PopupService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ICourtService, CourtService>();
    }
}