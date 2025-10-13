namespace KpoHW1.Domain.Entities.Things;

public abstract class Thing : IInventory
{
    public abstract ThingType Type { get; }
    public abstract int Number { get; }
}