using Microsoft.Extensions.DependencyInjection;

namespace KpoHW1.DI;

public static class CompositionRoot
{
    private static IServiceProvider? _services;

    public static IServiceProvider Services => _services ??= CreateServiceProvider();
    
    private static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();


        return services.BuildServiceProvider();
    }
}