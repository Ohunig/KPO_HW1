using KpoHW1.Domain.Entities.Things;

namespace KpoHW1.Screens;

public class InventoryReportScreen : IScreen
{
    private IReportBuilder Builder { get; }
    
    private IConsoleManager ConsoleManager { get; }
    
    private Zoo Zoo { get; }

    public InventoryReportScreen(IReportBuilder builder, IConsoleManager consoleManager, Zoo zoo)
    {
        Builder = builder;
        ConsoleManager = consoleManager;
        Zoo = zoo;
    }

    public void Render()
    {
        List<Animal> animals = Zoo.Animals;
        List<Thing> things = Zoo.Things;
        Builder.PushLine("Животные:");
        foreach (Animal animal in animals)
        {
            Builder.PushLine($"ID: {animal.Number}\nИмя: {animal.Name}\nВид: {animal.Type.ToString()}\n");
            Builder.PushLine("");
        }
        Builder.PushLine("Предметы:");
        foreach (Thing thing in things)
        {
            Builder.PushLine($"ID: {thing.Number}\nПредмет: {thing.Type.ToString()}\n");
            Builder.PushLine("");
        }
        Builder.PushLine($"Всего инвентаря: {animals.Count + things.Count}");
        ConsoleManager.Print(Builder.Build());
    }

    public ScreenAction HandleScreenAction()
    {
        ConsoleManager.WaitButtonPress();
        return ScreenAction.Previous();
    }
}