using System.Text;
using KpoHW1.Domain.Entities.Things;
using KpoHW1.Domain.Entities.Things.Types;

namespace KpoHW1.Screens;

/// <summary>
/// Экран меню добавления предметов
/// </summary>
public class AddThingScreen : IScreen
{
    /// <summary>
    /// Класс констант
    /// </summary>
    private static class Constants
    {
        public const String ChooseThingType = "Выберите один из предметов: ";

        public const String IncorrectData = "Введены неверные данные";
    }
    
    /// <summary>
    /// Менеджер инвентаризационных номеров
    /// </summary>
    private IInventoryNumberManager InventoryNumberManager { get; }
    
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
    /// <param name="inventoryNumberManager">Менеджер номеров</param>
    /// <param name="consoleManager">Консольный менеджер</param>
    /// <param name="zoo">Зоопарк</param>
    public AddThingScreen(IInventoryNumberManager inventoryNumberManager, IConsoleManager consoleManager,  Zoo zoo)
    {
        ConsoleManager = consoleManager;
        InventoryNumberManager = inventoryNumberManager;
        Zoo = zoo;
    }

    /// <summary>
    /// Отрисовка экрана
    /// </summary>
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

    /// <summary>
    /// Обработка действий пользователя
    /// </summary>
    /// <returns>Экранное событие</returns>
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

    /// <summary>
    /// Создаёт вещь
    /// </summary>
    /// <param name="type">Тип вещи</param>
    /// <param name="number">Номер</param>
    /// <returns>Вещь</returns>
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
    
    /// <summary>
    /// Отображение сообщения о некорректных данных
    /// </summary>
    private void IncorrectData()
    {
        ConsoleManager.PrintError(Constants.IncorrectData);
        ConsoleManager.WaitButtonPress();
    }
}