namespace KpoHW1;

// <summary>
/// Представляет кролика
/// </summary>
public class Rabbit : Herbo
{
    /// <summary>
    /// Здоровье кролика
    /// </summary>
    public override int Health { get; }
    
    /// <summary>
    /// Имя кролика
    /// </summary>
    public override String Name { get; }
    
    /// <summary>
    /// Вид животного
    /// </summary>
    public override AnimalType Type { get; } =  AnimalType.Rabbit;
    
    /// <summary>
    /// Инвентаризационный номер
    /// </summary>
    public override int Number { get; }
    
    /// <summary>
    /// Количество потребляемой еды
    /// </summary>
    public override int Food { get; }
    
    /// <summary>
    /// Степень доброты
    /// </summary>
    public override int Kindness { get; }
    
    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="health">Здоорвье</param>
    /// <param name="name">Имя</param>
    /// <param name="number">Номер</param>
    /// <param name="food">Количество еды</param>
    /// <param name="kindness">Доброта</param>
    /// <exception cref="Exception">Некорректные данные</exception>
    public Rabbit(int health, String name, int number, int food, int kindness)
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