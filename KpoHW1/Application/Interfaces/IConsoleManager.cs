namespace KpoHW1;

public interface IConsoleManager
{
    public void Print(String message);
    
    public void PrintError(String errorMessage);

    public String? GetStringResponse(String message);
    
    public int? GetIntResponse(String message);

    public void WaitButtonPress();
}