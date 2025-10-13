namespace KpoHW1;

public interface IScreenManager
{
    public void Render();

    public void Push(ScreenType screen);

    public ScreenType Pop();
    
    public void ClearScreen();
}