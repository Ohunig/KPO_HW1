using KpoHW1.Screens;
using Microsoft.Extensions.DependencyInjection;

namespace KpoHW1.DI;

/// <summary>
/// Класс конфигурации зависимостей
/// Отвечает за настройку и создание DI-контейнера
/// </summary>
public static class CompositionRoot
{
    /// <summary>
    /// Поле для хранения экземпляра контейнера
    /// </summary>
    private static IServiceProvider? _services;

    /// <summary>
    /// Предоставляет доступ к контейнеру зависимостей
    /// </summary>
    public static IServiceProvider Services => _services ??= CreateServiceProvider();
    
    /// <summary>
    /// Создание и настройка DI-контейнера
    /// </summary>
    /// <returns>Реализация IServiceProvider содержащая все нужные зависимости</returns>
    private static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IVetClinic, StandardVetClinic>();
        services.AddSingleton<Zoo>();
        
        // Регистрация менеджеров и билдера
        services.AddSingleton<IConsoleManager, StandardConsoleManager>();
        services.AddSingleton<IInventoryNumberManager, StandardInventoryNumberManager>();
        services.AddSingleton<IReportBuilder, StandardReportBuilder>();
        
        // Регистрация экранов
        services.AddTransient<MainScreen>();
        services.AddTransient<AddAnimalScreen>();
        services.AddTransient<AddThingScreen>();
        services.AddTransient<AnimalReportScreen>();
        services.AddTransient<FriendlyAnimalReportScreen>();
        services.AddTransient<InventoryReportScreen>();
        
        // Регистрация менеджера экранов
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
        
        // Создание и возврат контейнера
        return services.BuildServiceProvider();
    }
}