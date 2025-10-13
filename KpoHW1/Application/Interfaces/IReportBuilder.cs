using System.Text;

namespace KpoHW1;

public interface IReportBuilder
{
    public void Push(String message);

    public void PushLine(String message);

    public String Build();
}