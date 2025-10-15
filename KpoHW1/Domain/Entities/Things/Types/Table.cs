namespace KpoHW1.Domain.Entities.Things.Types;

/// <summary>
/// Класс представляющий стол
/// </summary>
public class Table : Thing
{
    /// <summary>
    /// Тип вещи
    /// </summary>
    public override ThingType Type { get; } = ThingType.Table;
    
    /// <summary>
    /// Инвентаризационный номер
    /// </summary>
    public override int Number { get; }

    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="number">Номер</param>
    public Table(int number)
    {
        Number = number;
    }
}