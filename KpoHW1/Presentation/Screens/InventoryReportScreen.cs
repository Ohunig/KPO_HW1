using KpoHW1.Domain.Entities.Things;

namespace KpoHW1.Screens;

/// <summary>
/// Экран отображения отчёта о инвентаре
/// </summary>
public class InventoryReportScreen : IScreen
{
    /// <summary>
    /// Сборщик отчётов
    /// </summary>
    private IReportBuilder Builder { get; }
    
    /// <summary>
    /// Консольный менеджер
    /// </summary>
    private IConsoleManager ConsoleManager { get; }
    
    /// <summary>
    /// Зоопарк
    /// </summary>
    private Zoo Zoo { get; }

    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="builder">Сборщик отчётов</param>
    /// <param name="consoleManager">Консольный менеджер</param>
    /// <param name="zoo">Зоопарк</param>
    public InventoryReportScreen(IReportBuilder builder, IConsoleManager consoleManager, Zoo zoo)
    {
        Builder = builder;
        ConsoleManager = consoleManager;
        Zoo = zoo;
    }

    /// <summary>
    /// Отрисовка экрана
    /// </summary>
    public void Render()
    {
        List<Animal> animals = Zoo.Animals;
        List<Thing> things = Zoo.Things;
        Builder.PushLine("Животные:");
        foreach (Animal animal in animals)
        {
            Builder.PushLine($"ID: {animal.Number}\nИмя: {animal.Name}\nВид: {animal.Type.ToString()}\n");
        }
        Builder.PushLine("Предметы:");
        foreach (Thing thing in things)
        {
            Builder.PushLine($"ID: {thing.Number}\nПредмет: {thing.Type.ToString()}\n");
        }
        Builder.PushLine($"Всего инвентаря: {animals.Count + things.Count}");
        ConsoleManager.Print(Builder.Build());
    }

    /// <summary>
    /// Обработка пользовательских действий
    /// </summary>
    /// <returns>Экранное событие</returns>
    public ScreenAction HandleScreenAction()
    {
        ConsoleManager.WaitButtonPress();
        return ScreenAction.Previous();
    }
}