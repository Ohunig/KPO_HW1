namespace KpoHW1;

/// <summary>
/// Представляет действие, выполняемое при обработке экранов в менеджере экранов.
/// Используется для управления переходами между экранами или завершением работы приложения.
/// </summary>
public class ScreenAction
{
    /// <summary>
    /// Тип выполняемого действия
    /// </summary>
    public ScreenActionType ActionType { get; }

    /// <summary>
    /// Тип экрана, к которому необходимо перейти либо null.
    /// </summary>
    public ScreenType? TypeScreen { get; }

    /// <summary>
    /// Стандартный конструктор
    /// </summary>
    /// <param name="actionType">Тип выполняемого действия.</param>
    /// <param name="screenType">Тип целевого экрана или null.</param>
    public ScreenAction(ScreenActionType actionType, ScreenType? screenType = null)
    {
        ActionType = actionType;
        TypeScreen = screenType;
    }
    
    /// <summary>
    /// Возвращает действие, не требующее перехода или изменения экрана.
    /// </summary>
    /// <returns>Действие</returns>
    public static ScreenAction Nothing()
    {
        return new ScreenAction(ScreenActionType.Nothing);
    }

    /// <summary>
    /// Возвращает действие, указывающее на переход к следующему экрану.
    /// </summary>
    /// <param name="screenType">Тип экрана к которому переходим</param>
    /// <returns>Действие перехода на следующий экран</returns>
    public static ScreenAction Next(ScreenType screenType)
    {
        return new ScreenAction(ScreenActionType.Next, screenType);
    }

    /// <summary>
    /// Возвращает действие, указывающее на возврат к предыдущему экрану.
    /// </summary>
    /// <returns>Действие</returns>
    public static ScreenAction Previous()
    {
        return new ScreenAction(ScreenActionType.Previous);
    }

    /// <summary>
    /// Возвращает действие, указывающее на завершение работы приложения.
    /// </summary>
    /// <returns>Действие</returns>
    public static ScreenAction Exit()
    {
        return new ScreenAction(ScreenActionType.Exit);
    }

    /// <summary>
    /// Возвращает действие, указывающее на переход к главному экрану.
    /// </summary>
    /// <returns>Действие</returns>
    public static ScreenAction ToMain()
    {
        return new ScreenAction(ScreenActionType.ToMain);
    }
}