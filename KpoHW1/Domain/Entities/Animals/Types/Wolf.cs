namespace KpoHW1;

public class Wolf : Predator
{
    public override int Health { get; }
    public override String Name { get; }
    public override AnimalType Type { get; } =  AnimalType.Wolf;
    public override int Number { get; }
    public override int Food { get; }
    
    public Wolf(int health, String name, int number, int food)
    {
        if (health < 0 || health > 10) throw new ArgumentOutOfRangeException(nameof(health));
        if (food < 0) throw new ArgumentOutOfRangeException(nameof(food));
        Health = health;
        Name = name;
        Number = number;
        Food = food;
    }
}