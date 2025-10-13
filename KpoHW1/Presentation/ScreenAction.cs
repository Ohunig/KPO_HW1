namespace KpoHW1;

public class ScreenAction
{
    public ScreenActionType ActionType { get; }

    public ScreenType? TypeScreen { get; }

    public ScreenAction(ScreenActionType actionType, ScreenType? screenType = null)
    {
        ActionType = actionType;
        TypeScreen = screenType;
    }
    
    public static ScreenAction Nothing()
    {
        return new ScreenAction(ScreenActionType.Nothing);
    }

    public static ScreenAction Next(ScreenType screenType)
    {
        return new ScreenAction(ScreenActionType.Next, screenType);
    }

    public static ScreenAction Previous()
    {
        return new ScreenAction(ScreenActionType.Previous);
    }

    public static ScreenAction Exit()
    {
        return new ScreenAction(ScreenActionType.Exit);
    }

    public static ScreenAction ToMain()
    {
        return new ScreenAction(ScreenActionType.ToMain);
    }
}