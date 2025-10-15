namespace KpoHW1;

/// <summary>
/// Определяет функционал экрана
/// </summary>
public interface IScreen
{
    /// <summary>
    /// Рендерит экран
    /// </summary>
    public void Render();
    
    /// <summary>
    /// Обрабатывает взаимодействия с экраном
    /// </summary>
    /// <returns>Экранное событие</returns>
    public ScreenAction HandleScreenAction();
}