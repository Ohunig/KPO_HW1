using System.Text;
using KpoHW1.Domain.Entities.Things;
using KpoHW1.Domain.Entities.Things.Types;

namespace KpoHW1.Screens;

public class AddThingScreen : IScreen
{
    private static class Constants
    {
        public const String ChooseThingType = "Выберите один из предметов: ";

        public const String IncorrectData = "Введены неверные данные";
    }
    
    private IInventoryNumberManager InventoryNumberManager { get; }
    
    private IConsoleManager ConsoleManager { get; }
    
    private Zoo Zoo { get; }
    
    public AddThingScreen(IInventoryNumberManager inventoryNumberManager, IConsoleManager consoleManager,  Zoo zoo)
    {
        ConsoleManager = consoleManager;
        InventoryNumberManager = inventoryNumberManager;
        Zoo = zoo;
    }

    public void Render()
    {
        StringBuilder stringBuilder = new StringBuilder();
        ThingType[] thingTypes = Enum.GetValues<ThingType>();
        for (int i = 0; i < thingTypes.Length; i++)
        {
            stringBuilder.AppendLine($"{i + 1}. {thingTypes[i].ToString()}");
        }
        ConsoleManager.Print(stringBuilder.ToString());
    }

    public ScreenAction HandleScreenAction()
    {
        int? command = ConsoleManager.GetIntResponse(Constants.ChooseThingType);
        if (command is null || command < 1 || command > Enum.GetValues<ThingType>().Length)
        {
            IncorrectData();
            return ScreenAction.Nothing();
        }
        Thing? thing = CreateThing(Enum.GetValues<ThingType>()[command.Value - 1], InventoryNumberManager.GetNumber());
        Zoo.AddThing(thing!);
        return ScreenAction.Previous();
    }

    private Thing? CreateThing(ThingType type, int number)
    {
        switch (type)
        {
            case ThingType.Table:
                return new Table(number);
            case ThingType.Computer:
                return new Computer(number);
            default:
                return null;
        }
    }
    
    private void IncorrectData()
    {
        ConsoleManager.PrintError(Constants.IncorrectData);
        ConsoleManager.WaitButtonPress();
    }
}