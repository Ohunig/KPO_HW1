using System.Text;

namespace KpoHW1.Screens;

public class MainScreen : IScreen
{
    private IConsoleManager ConsoleManager { get; }

    public MainScreen(IConsoleManager consoleManager)
    {
        ConsoleManager = consoleManager;
    }

    public void Render()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("1. Добавить животное");
        stringBuilder.AppendLine("2. Добавить предмет");
        stringBuilder.AppendLine("3. Отчёт о животных");
        stringBuilder.AppendLine("4. Отчёт о добрых животных");
        stringBuilder.AppendLine("5. Отчёт о инвентаре");
        stringBuilder.AppendLine("6. Закончить работу");
        ConsoleManager.Print(stringBuilder.ToString());
    }

    public ScreenAction HandleScreenAction()
    {
        int? command = ConsoleManager.GetIntResponse("Выберите действие: ");
        switch (command)
        {
            case 1:
                return ScreenAction.Next(ScreenType.AddAnimalScreen);
            case 2:
                return ScreenAction.Next(ScreenType.AddThingScreen);
            case 3:
                return ScreenAction.Next(ScreenType.AnimalReportScreen);
            case 4:
                return ScreenAction.Next(ScreenType.FriendlyAnimalReportScreen);
            case 5:
                return ScreenAction.Next(ScreenType.InventoryReportScreen);
            case 6:
                return ScreenAction.Exit();
            default:
                ConsoleManager.PrintError("Некорректная команда");
                ConsoleManager.WaitButtonPress();
                return ScreenAction.Nothing();
        }
    }
}