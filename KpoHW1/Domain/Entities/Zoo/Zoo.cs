using KpoHW1.Domain.Entities.Things;

namespace KpoHW1;

/// <summary>
/// Класс представляющий зоопарк
/// </summary>
public class Zoo
{
    /// <summary>
    /// Список животных
    /// </summary>
    public List<Animal> Animals { get; } = new List<Animal>();

    /// <summary>
    /// Список вещей
    /// </summary>
    public List<Thing> Things { get; } = new List<Thing>();
    
    /// <summary>
    /// Ветеринарная клиника
    /// </summary>
    private IVetClinic Clinic { get; }

    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="clinic">Ветеринарная клиника</param>
    public Zoo(IVetClinic clinic)
    {
        Clinic = clinic;
    }

    /// <summary>
    /// Добавление нового животного в зоопарк
    /// </summary>
    /// <param name="animal">Животное</param>
    /// <returns>true если животное добавлено, false иначе</returns>
    public bool AddAnimal(Animal animal)
    {
        if (!Clinic.IsAnimalHealthy(animal))
        {
            return false;
        }
        Animals.Add(animal);
        return true;
    }

    /// <summary>
    /// Добавление новой вещи
    /// </summary>
    /// <param name="thing">Вещь</param>
    public void AddThing(Thing thing)
    {
        Things.Add(thing);
    }
}