using KpoHW1.Domain.Entities.Things;

namespace KpoHW1;

public class Zoo
{
    public List<Animal> Animals { get; } = new List<Animal>();

    public List<Thing> Things { get; } = new List<Thing>();
    
    private IVetClinic Clinic { get; }

    public Zoo(IVetClinic clinic)
    {
        Clinic = clinic;
    }

    public bool AddAnimal(Animal animal)
    {
        if (!Clinic.IsAnimalHealthy(animal))
        {
            return false;
        }
        Animals.Add(animal);
        return true;
    }

    public void AddThing(Thing thing)
    {
        Things.Add(thing);
    }
}