namespace KpoHW1.Domain.Entities.Things.Types;

/// <summary>
/// Класс представляющий компьютер
/// </summary>
public class Computer : Thing
{
    /// <summary>
    /// Тип вещи
    /// </summary>
    public override ThingType Type { get; } = ThingType.Computer;
    
    /// <summary>
    /// Инвентаризационный номер
    /// </summary>
    public override int Number { get; }

    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="number">Номер</param>
    public Computer(int number)
    {
        Number = number;
    }
}