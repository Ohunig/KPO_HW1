namespace KpoHW1;

/// <summary>
/// Представляет волка
/// </summary>
public class Wolf : Predator
{
    /// <summary>
    /// Здоровье волка
    /// </summary>
    public override int Health { get; }
    
    /// <summary>
    /// Имя волка
    /// </summary>
    public override String Name { get; }
    
    /// <summary>
    /// Тип животного
    /// </summary>
    public override AnimalType Type { get; } =  AnimalType.Wolf;
    
    /// <summary>
    /// Инвентаризационный номер
    /// </summary>
    public override int Number { get; }
    
    /// <summary>
    /// Количество потребляемой еды
    /// </summary>
    public override int Food { get; }
    
    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="health">Здоровье</param>
    /// <param name="name">Имя</param>
    /// <param name="number">Номер</param>
    /// <param name="food">Количество еды</param>
    /// <exception cref="Exception">Некорректные данные</exception>
    public Wolf(int health, String name, int number, int food)
    {
        if (health < 0 || health > 10) throw new Exception(nameof(health));
        if (food < 0) throw new Exception(nameof(food));
        Health = health;
        Name = name;
        Number = number;
        Food = food;
    }
}