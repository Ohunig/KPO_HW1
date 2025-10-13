namespace KpoHW1;

public class StandardConsoleManager : IConsoleManager
{
    public void Print(String message)
    {
        Console.WriteLine(message);
    }

    public void PrintError(String errorMessage)
    {
        Console.WriteLine(errorMessage);
    }

    public String? GetStringResponse(String message = "")
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    public int? GetIntResponse(String message = "")
    {
        Console.Write(message);
        String? input = Console.ReadLine();
        if (input is null) return null;
        try
        {
            return int.Parse(input);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void WaitButtonPress()
    {
        Console.Write("Нажмите Enter чтобы продолжить...");
        Console.ReadLine();
    }
}