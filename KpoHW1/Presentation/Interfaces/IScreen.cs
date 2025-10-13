namespace KpoHW1;

public interface IScreen
{
    public void Render();
    
    public ScreenAction HandleScreenAction();
}