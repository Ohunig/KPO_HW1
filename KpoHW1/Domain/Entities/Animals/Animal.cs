namespace KpoHW1;

public abstract class Animal : IAlive, IInventory
{
    public abstract int Health { get; }
    public abstract String Name { get; }
    public abstract AnimalType Type { get; }
    public abstract int Number { get; }
    public abstract int Food { get; }
}