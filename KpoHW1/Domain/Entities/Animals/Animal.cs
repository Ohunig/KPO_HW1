namespace KpoHW1;

/// <summary>
/// Класс для представления абстрактного животного
/// </summary>
public abstract class Animal : IAlive, IInventory
{
    
    /// <summary>
    /// Здоровье животного
    /// </summary>
    public abstract int Health { get; }
    
    /// <summary>
    /// Имя животного
    /// </summary>
    public abstract String Name { get; }
    
    /// <summary>
    /// Вид животного
    /// </summary>
    public abstract AnimalType Type { get; }
    
    /// <summary>
    /// Инвентаризационный номер животного
    /// </summary>
    public abstract int Number { get; }
    
    /// <summary>
    /// Количество еды потребляемое животным
    /// </summary>
    public abstract int Food { get; }
}