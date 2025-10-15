namespace KpoHW1;

/// <summary>
/// Стандартный менеджер номеров инвентаря
/// </summary>
public class StandardInventoryNumberManager : IInventoryNumberManager
{
    /// <summary>
    /// Последний не выданный номер
    /// </summary>
    private int Number { get; set; } = 1;

    /// <summary>
    /// Выдаёт уникальный ID
    /// </summary>
    /// <returns>Уникальный ID</returns>
    public int GetNumber()
    {
        return Number++;
    }
}