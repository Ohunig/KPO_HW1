namespace KpoHW1;

public class StandardInventoryNumberManager : IInventoryNumberManager
{
    private int Number { get; set; } = 0;

    public int GetNumber()
    {
        return Number++;
    }
}