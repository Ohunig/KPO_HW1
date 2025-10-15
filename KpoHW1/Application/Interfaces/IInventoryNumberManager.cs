namespace KpoHW1;

/// <summary>
/// Определяет функционал выдачи уникальных номеров
/// </summary>
public interface IInventoryNumberManager
{
    /// <summary>
    /// Возвращает уникальный номер
    /// </summary>
    /// <returns>Уникальный номер</returns>
    public int GetNumber();
}