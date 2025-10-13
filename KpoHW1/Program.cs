using KpoHW1;
using KpoHW1.DI;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = CompositionRoot.Services;
IScreenManager screenManager = serviceProvider.GetRequiredService<IScreenManager>();
try
{
    screenManager.Render();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}