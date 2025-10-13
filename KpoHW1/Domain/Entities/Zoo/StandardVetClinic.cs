namespace KpoHW1;

public class StandardVetClinic : IVetClinic
{
    public bool IsAnimalHealthy(Animal animal)
    {
        return animal.Health >= 5;
    }
}