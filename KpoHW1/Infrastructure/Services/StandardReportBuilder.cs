using System.Text;

namespace KpoHW1;

public class StandardReportBuilder : IReportBuilder
{
    private StringBuilder _builder = new StringBuilder();
    
    public void Push(String message)
    {
        _builder.Append(message);
    }

    public void PushLine(String message)
    {
        _builder.AppendLine(message);
    }

    public String Build()
    {
        _builder.AppendLine("Конец отчёта");
        String returnValue = _builder.ToString();
        _builder.Clear();
        return returnValue;
    }
}