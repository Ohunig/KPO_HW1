namespace KpoHW1;

/// <summary>
/// Стандартный менеджер экранов
/// </summary>
public class StandardScreenManager : IScreenManager
{
    /// <summary>
    /// Список экранов
    /// </summary>
    private IScreen[] Screens { get; }

    /// <summary>
    /// Стартовый экран
    /// </summary>
    private ScreenType StartScreen { get; }
    
    /// <summary>
    /// Стек экранов
    /// </summary>
    private Stack<ScreenType> ScreenStack { get; }

    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="screens">Список экранов</param>
    /// <param name="startScreen">Стартовый экран</param>
    public StandardScreenManager(IScreen[] screens, ScreenType startScreen)
    {
        Screens = screens;
        StartScreen = startScreen;
        ScreenStack = new Stack<ScreenType>();
        ScreenStack.Push(startScreen);
    }
    
    /// <summary>
    /// Рендерит верхний экран на стеке
    /// </summary>
    /// <exception cref="Exception">Ошибки связанные с отображением экранов</exception>
    public void Render() 
    {
        while (ScreenStack.Count > 0) {
            ClearScreen();
            if (Screens.Length <= (int)ScreenStack.Peek())
            {
                throw new Exception("Экран недоступен");
            }
            IScreen screen = Screens[(int)ScreenStack.Peek()];
            screen.Render();
            // Обработка пользовательских действий
            ScreenAction action = screen.HandleScreenAction();
            // Обработка экранных событий
            switch (action.ActionType)
            {
                case ScreenActionType.Nothing:
                    break;
                case ScreenActionType.Next:
                    if (action.TypeScreen is null)
                    {
                        throw new Exception("Тип экрана не может быть null");
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

    /// <summary>
    /// Добавление экрана в стек
    /// </summary>
    /// <param name="screen">Экран</param>
    public void Push(ScreenType screen)
    {
        ScreenStack.Push(screen);
    }

    /// <summary>
    /// Удаляет экран с вершины стека
    /// </summary>
    /// <returns>Тип удалённого экрана</returns>
    public ScreenType Pop()
    {
        return ScreenStack.Pop();
    }

    /// <summary>
    /// Очистка консоли
    /// </summary>
    public void ClearScreen()
    {
        Console.Clear();
    }
}