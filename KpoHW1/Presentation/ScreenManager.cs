namespace KpoHW1;

public class StandardScreenManager : IScreenManager
{
    private IScreen[] Screens { get; }

    private ScreenType StartScreen { get; }
    
    private Stack<ScreenType> ScreenStack { get; }

    public StandardScreenManager(IScreen[] screens, ScreenType startScreen)
    {
        Screens = screens;
        StartScreen = startScreen;
        ScreenStack = new Stack<ScreenType>();
        ScreenStack.Push(startScreen);
    }
    
    public void Render() 
    {
        while (ScreenStack.Count > 0) {
            ClearScreen();
            if (Screens.Length <= (int)ScreenStack.Peek())
            {
                throw new Exception("Screen is not available");
            }
            IScreen screen = Screens[(int)ScreenStack.Peek()];
            screen.Render();
            ScreenAction action = screen.HandleScreenAction();
            switch (action.ActionType)
            {
                case ScreenActionType.Nothing:
                    break;
                case ScreenActionType.Next:
                    if (action.TypeScreen is null)
                    {
                        throw new Exception("Screen type cannot be null");
                    }
                    Push(action.TypeScreen.Value);
                    break;
                case ScreenActionType.Previous:
                    Pop();
                    break;
                case ScreenActionType.ToMain:
                    while (ScreenStack.Count > 1)
                    {
                        Pop();
                    }
                    break;
                case ScreenActionType.Exit:
                    while (ScreenStack.Count > 0)
                    {
                        Pop();
                    }
                    break;  
            }
        }
        ClearScreen();
    }

    public void Push(ScreenType screen)
    {
        ScreenStack.Push(screen);
    }

    public ScreenType Pop()
    {
        return ScreenStack.Pop();
    }

    public void ClearScreen()
    {
        Console.Clear();
    }
}