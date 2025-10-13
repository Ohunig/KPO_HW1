namespace KpoHW1.Screens;

public class FriendlyAnimalReportScreen : IScreen
{
    private IReportBuilder Builder { get; }
    
    private IConsoleManager ConsoleManager { get; }
    
    private Zoo Zoo { get; }

    public FriendlyAnimalReportScreen(IReportBuilder builder, IConsoleManager consoleManager, Zoo zoo)
    {
        Builder = builder;
        ConsoleManager = consoleManager;
        Zoo = zoo;
    }

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

    public ScreenAction HandleScreenAction()
    {
        ConsoleManager.WaitButtonPress();
        return ScreenAction.Previous();
    }
}