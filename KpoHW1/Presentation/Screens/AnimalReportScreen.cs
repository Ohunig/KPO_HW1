namespace KpoHW1.Screens;

public class AnimalReportScreen : IScreen
{
    private IReportBuilder Builder { get; }
    
    private IConsoleManager ConsoleManager { get; }
    
    private Zoo Zoo { get; }

    public AnimalReportScreen(IReportBuilder builder, IConsoleManager consoleManager, Zoo zoo)
    {
        Builder = builder;
        ConsoleManager = consoleManager;
        Zoo = zoo;
    }

    public void Render()
    {
        List<Animal> animals = Zoo.Animals;
        foreach (Animal animal in animals)
        {
            Builder.PushLine($"ID: {animal.Number}\nИмя: {animal.Name}\nВид: {animal.Type.ToString()}\nКоличество еды в день (кг): {animal.Food}");
            Builder.PushLine("");
        }
        Builder.PushLine($"Всего животных: {animals.Count}");
        ConsoleManager.Print(Builder.Build());
    }

    public ScreenAction HandleScreenAction()
    {
        ConsoleManager.WaitButtonPress();
        return ScreenAction.Previous();
    }
}