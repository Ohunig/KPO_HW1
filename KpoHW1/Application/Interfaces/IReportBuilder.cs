using System.Text;

namespace KpoHW1;

/// <summary>
/// Определяет функционал билдера отчётов
/// </summary>
public interface IReportBuilder
{
    /// <summary>
    /// Добавление текста в билдер
    /// </summary>
    /// <param name="message">Текст</param>
    public void Push(String message);

    /// <summary>
    /// Добавление строки в билдер
    /// </summary>
    /// <param name="message">Строка</param>
    public void PushLine(String message);

    /// <summary>
    /// Формирование итогового отчёта
    /// </summary>
    /// <returns>Текст отчёта</returns>
    public String Build();
}