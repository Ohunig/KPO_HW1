using System.Text;

namespace KpoHW1.Screens;

/// <summary>
/// Экран меню добавления нового животного
/// </summary>
public class AddAnimalScreen : IScreen
{
    /// <summary>
    /// Класс констант
    /// </summary>
    private static class Constants
    {
        public const String ChooseAnimalType = "Выберите один из видов животных: ";
        public const String AnimalHealth = "Введите насколько здорово животное (0-10): ";
        public const String AnimalName = "Введите имя животного: ";
        public const String AnimalFood = "Введите количество потребляемой еды (>= 0): ";
        public const String AnimalKindness = "Введите степень доброты (0-10): ";

        public const String IncorrectData = "Введены неверные данные";
        public const String AnimalNotAdded = "Животное не было добавлено по состоянию здоровья";
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
    public AddAnimalScreen(IInventoryNumberManager inventoryNumberManager, IConsoleManager consoleManager,  Zoo zoo)
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
        AnimalType[] animalTypes = Enum.GetValues<AnimalType>();
        // Отображение списка видов зверей
        for (int i = 0; i < animalTypes.Length; i++)
        {
            stringBuilder.AppendLine($"{i + 1}. {animalTypes[i].ToString()}");
        }
        stringBuilder.AppendLine();
        ConsoleManager.Print(stringBuilder.ToString());
    }

    /// <summary>
    /// Обработка действий пользователя
    /// </summary>
    /// <returns>Экранное событие</returns>
    public ScreenAction HandleScreenAction()
    {
        int? command = ConsoleManager.GetIntResponse(Constants.ChooseAnimalType);
        if (command is null || command < 1 || command > Enum.GetValues<AnimalType>().Length)
        {
            IncorrectData();
            return ScreenAction.Nothing();
        }
        // Получение всех данных от пользователя
        int? health = ConsoleManager.GetIntResponse(Constants.AnimalHealth);
        String? name = ConsoleManager.GetStringResponse(Constants.AnimalName);
        int? food = ConsoleManager.GetIntResponse(Constants.AnimalFood);
        if (health is null || name is null || food is null)
        {
            IncorrectData();
            return ScreenAction.Nothing();
        }
        try
        {
            // Создание животного
            Animal animal = CreateAnimal(
                Enum.GetValues<AnimalType>()[command.Value - 1],
                health.Value,
                name,
                InventoryNumberManager.GetNumber(),
                food.Value);
            if (animal is null)
            {
                IncorrectData();
                return ScreenAction.Nothing();
            }
            // Добавление животного
            bool added = Zoo.AddAnimal(animal);
            if (!added)
            {
                ConsoleManager.Print(Constants.AnimalNotAdded);
                ConsoleManager.WaitButtonPress();
                return ScreenAction.Nothing();
            }
            return ScreenAction.Previous();
        }
        catch (Exception)
        {
            IncorrectData();
            return ScreenAction.Nothing();
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
    
    /// <summary>
    /// Создаёт животное
    /// </summary>
    /// <param name="animalType">Вид животного</param>
    /// <param name="health">Здоровье</param>
    /// <param name="name">Имя</param>
    /// <param name="number">Номер</param>
    /// <param name="food">Количество еды</param>
    /// <returns>Животное</returns>
    private Animal? CreateAnimal(AnimalType animalType, int health, String name, int number, int food)
    {
        int? kindness;
        switch (animalType)
        {
            case AnimalType.Monkey:
                kindness = ConsoleManager.GetIntResponse(Constants.AnimalKindness);
                if (kindness is null)
                {
                    return null;
                }
                return new Monkey(health, name, number, food, kindness.Value);
            case AnimalType.Rabbit:
                kindness = ConsoleManager.GetIntResponse(Constants.AnimalKindness);
                if (kindness is null)
                {
                    return null;
                }
                return new Rabbit(health, name, number, food, kindness.Value);
            case AnimalType.Tiger:
                return new Tiger(health, name, number, food);
            case AnimalType.Wolf:
                return new Wolf(health, name, number, food);
            default:
                return null;
        }
    }
}