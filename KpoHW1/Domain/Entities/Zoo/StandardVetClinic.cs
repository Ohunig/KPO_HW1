namespace KpoHW1;

/// <summary>
/// Стандартная ветеринарная клиника
/// </summary>
public class StandardVetClinic : IVetClinic
{
    /// <summary>
    /// Проверяет здорово ли животное
    /// </summary>
    /// <param name="animal">Животное</param>
    /// <returns>true если здорово, false иначе</returns>
    public bool IsAnimalHealthy(Animal animal)
    {
        return animal.Health > 5;
    }
}