namespace KpoHW1;

/// <summary>
/// Определяет функционал менеджеров экранов
/// </summary>
public interface IScreenManager
{
    /// <summary>
    /// Рендерит верхний на стеке экран
    /// </summary>
    public void Render();

    /// <summary>
    /// Добавляет экран в стек
    /// </summary>
    /// <param name="screen">Тип экрана</param>
    public void Push(ScreenType screen);

    /// <summary>
    /// Убирает верхний в стеке экран
    /// </summary>
    /// <returns>Тип убранного экрана</returns>
    public ScreenType Pop();
    
    /// <summary>
    /// Очищает экран
    /// </summary>
    public void ClearScreen();
}