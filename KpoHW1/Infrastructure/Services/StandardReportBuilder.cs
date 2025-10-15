using System.Text;

namespace KpoHW1;

/// <summary>
/// Стандартный сборщик отчётов
/// </summary>
public class StandardReportBuilder : IReportBuilder
{
    /// <summary>
    /// Сборщик строк
    /// </summary>
    private StringBuilder _builder = new StringBuilder();
    
    /// <summary>
    /// Добавление текста в билдер
    /// </summary>
    /// <param name="message">Текст</param>
    public void Push(String message)
    {
        _builder.Append(message);
    }

    /// <summary>
    /// Добавление строки в билдер
    /// </summary>
    /// <param name="message">Строка</param>
    public void PushLine(String message)
    {
        _builder.AppendLine(message);
    }

    /// <summary>
    /// Формирование итогового отчёта
    /// </summary>
    /// <returns>Текст отчёта</returns>
    public String Build()
    {
        _builder.AppendLine("Конец отчёта");
        String returnValue = _builder.ToString();
        _builder.Clear();
        return returnValue;
    }
}