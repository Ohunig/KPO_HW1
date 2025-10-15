namespace KpoHW1.Domain.Entities.Things;

/// <summary>
/// Класс для представления абстрактного предмета инвентаря
/// </summary>
public abstract class Thing : IInventory
{
    /// <summary>
    /// Тип предмета
    /// </summary>
    public abstract ThingType Type { get; }
    
    /// <summary>
    /// Инвентаризационный номер
    /// </summary>
    public abstract int Number { get; }
}