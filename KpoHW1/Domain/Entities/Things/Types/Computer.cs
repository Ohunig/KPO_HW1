namespace KpoHW1.Domain.Entities.Things.Types;

public class Computer : Thing
{
    public override ThingType Type { get; } = ThingType.Computer;
    public override int Number { get; }

    public Computer(int number)
    {
        Number = number;
    }
}