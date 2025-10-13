using KpoHW1.Screens;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW1.DI;

public static class CompositionRoot
{
    private static IServiceProvider? _services;

    public static IServiceProvider Services => _services ??= CreateServiceProvider();
    
    private static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IVetClinic, StandardVetClinic>();
        services.AddSingleton<Zoo>();
        
        services.AddSingleton<IConsoleManager, StandardConsoleManager>();
        services.AddSingleton<IInventoryNumberManager, StandardInventoryNumberManager>();
        services.AddSingleton<IReportBuilder, StandardReportBuilder>();
        
        services.AddTransient<MainScreen>();
        services.AddTransient<AddAnimalScreen>();
        services.AddTransient<AddThingScreen>();
        services.AddTransient<AnimalReportScreen>();
        services.AddTransient<FriendlyAnimalReportScreen>();
        services.AddTransient<InventoryReportScreen>();
        
        services.AddSingleton<IScreenManager>(provider =>
        {
            var screens = new IScreen[]
            {
                provider.GetRequiredService<MainScreen>(),
                provider.GetRequiredService<AddAnimalScreen>(),
                provider.GetRequiredService<AddThingScreen>(),
                provider.GetRequiredService<AnimalReportScreen>(),
                provider.GetRequiredService<FriendlyAnimalReportScreen>(),
                provider.GetRequiredService<InventoryReportScreen>()
            };
            
            return new StandardScreenManager(screens, ScreenType.MainScreen);
        });

        return services.BuildServiceProvider();
    }
}