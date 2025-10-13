using System.Text;

namespace KpoHW1.Screens;

public class AddAnimalScreen : IScreen
{
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
    private IInventoryNumberManager InventoryNumberManager { get; }
    
    private IConsoleManager ConsoleManager { get; }
    
    private Zoo Zoo { get; }

    public AddAnimalScreen(IInventoryNumberManager inventoryNumberManager, IConsoleManager consoleManager,  Zoo zoo)
    {
        ConsoleManager = consoleManager;
        InventoryNumberManager = inventoryNumberManager;
        Zoo = zoo;
    }

    public void Render()
    {
        StringBuilder stringBuilder = new StringBuilder();
        AnimalType[] animalTypes = Enum.GetValues<AnimalType>();
        for (int i = 0; i < animalTypes.Length; i++)
        {
            stringBuilder.AppendLine($"{i + 1}. {animalTypes[i].ToString()}");
        }
        stringBuilder.AppendLine();
        ConsoleManager.Print(stringBuilder.ToString());
    }

    public ScreenAction HandleScreenAction()
    {
        int? command = ConsoleManager.GetIntResponse(Constants.ChooseAnimalType);
        if (command is null || command < 1 || command > Enum.GetValues<AnimalType>().Length)
        {
            IncorrectData();
            return ScreenAction.Nothing();
        }

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

    private void IncorrectData()
    {
        ConsoleManager.PrintError(Constants.IncorrectData);
        ConsoleManager.WaitButtonPress();
    }
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