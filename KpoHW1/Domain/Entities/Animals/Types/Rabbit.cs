namespace KpoHW1;

public class Rabbit : Herbo
{
    public override int Health { get; }
    public override String Name { get; }
    public override AnimalType Type { get; } =  AnimalType.Rabbit;
    public override int Number { get; }
    public override int Food { get; }
    public override int Kindness { get; }
    
    public Rabbit(int health, String name, int number, int food, int kindness)
    {
        if (health < 0 || health > 10) throw new ArgumentOutOfRangeException(nameof(health));
        if (food < 0) throw new ArgumentOutOfRangeException(nameof(food));
        if (kindness < 0 || kindness > 10) throw new ArgumentOutOfRangeException(nameof(kindness));
        Health = health;
        Name = name;
        Number = number;
        Food = food;
        Kindness = kindness;
    }
}