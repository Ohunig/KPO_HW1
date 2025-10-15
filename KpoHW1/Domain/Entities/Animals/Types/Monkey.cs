namespace KpoHW1;

/// <summary>
/// Представляет травоядную обезьяну
/// </summary>
public class Monkey : Herbo
{
    /// <summary>
    /// Здоровье обезьяны
    /// </summary>
    public override int Health { get; }
    
    /// <summary>
    /// Имя обезьяны
    /// </summary>
    public override String Name { get; }
    
    /// <summary>
    /// Вид животного
    /// </summary>
    public override AnimalType Type { get; } =  AnimalType.Monkey;
    
    /// <summary>
    /// Инвентаризационный номер
    /// </summary>
    public override int Number { get; }
    
    /// <summary>
    /// Количество еды нужной животному
    /// </summary>
    public override int Food { get; }
    
    /// <summary>
    /// Степень доброты
    /// </summary>
    public override int Kindness { get; }
    
    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="health">Здоровье</param>
    /// <param name="name">Имя</param>
    /// <param name="number">Номер</param>
    /// <param name="food">Количество еды</param>
    /// <param name="kindness">Доброта</param>
    /// <exception cref="Exception">Некорректные данные</exception>
    public Monkey(int health, String name, int number, int food, int kindness)
    {
        if (health < 0 || health > 10) throw new Exception(nameof(health));
        if (food < 0) throw new Exception(nameof(food));
        if (kindness < 0 || kindness > 10) throw new Exception(nameof(kindness));
        Health = health;
        Name = name;
        Number = number;
        Food = food;
        Kindness = kindness;
    }
}