namespace KpoHW1;

/// <summary>
/// Определяет функционал ветеринарной клиники
/// </summary>
public interface IVetClinic
{
    /// <summary>
    /// Проверяет здорово ли животное
    /// </summary>
    /// <param name="animal">Животное</param>
    /// <returns>true если здорово, false иначе</returns>
    public bool IsAnimalHealthy(Animal animal);
}