namespace KpoHW1.Domain.Entities.Things.Types;

public class Table : Thing
{
    public override ThingType Type { get; } = ThingType.Table;
    public override int Number { get; }

    public Table(int number)
    {
        Number = number;
    }
}