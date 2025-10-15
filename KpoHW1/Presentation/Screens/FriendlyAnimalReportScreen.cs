namespace KpoHW1.Screens;

/// <summary>
/// Экран отображения отчёта о дружелюбных животных
/// </summary>
public class FriendlyAnimalReportScreen : IScreen
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
    public FriendlyAnimalReportScreen(IReportBuilder builder, IConsoleManager consoleManager, Zoo zoo)
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
        int friendlyAnimals = 0;
        List<Animal> animals = Zoo.Animals;
        foreach (Animal animal in animals)
        {
            if (animal is Herbo && ((Herbo)animal).Kindness > 5)
            {
                friendlyAnimals++;
                Builder.PushLine($"ID: {animal.Number}\nИмя: {animal.Name}\nВид: {animal.Type.ToString()}\nДоброта: {((Herbo)animal).Kindness}");
                Builder.PushLine("");
            }
        }
        Builder.PushLine($"Всего дружелюбных животных: {friendlyAnimals}");
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