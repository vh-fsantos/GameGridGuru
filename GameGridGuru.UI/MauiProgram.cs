using CommunityToolkit.Maui;
using GameGridGuru.Infraestructure;
using GameGridGuru.UI.DependencyInjection;

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

        builder.Services.AddDbContext<PostgresDbContext>(ServiceLifetime.Transient);
        
        builder.Services.InjectUi();
        builder.Services.InjectRepositories();
        builder.Services.InjectApplicationServices();
        
        return builder.Build();
    }
}