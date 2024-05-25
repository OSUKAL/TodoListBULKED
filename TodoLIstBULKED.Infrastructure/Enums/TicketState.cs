namespace TodoLIstBULKED.Infrastructure.Enums;

/// <summary>
/// Состояние задачи
/// </summary>
public enum TicketState
{
    /// <summary>
    /// Неизвестное
    /// </summary>
    Unknown = 0,
    
    /// <summary>
    /// В работе
    /// </summary>
    InProgress = 1,
    
    /// <summary>
    /// Выполнена
    /// </summary>
    Done = 2,
    
    /// <summary>
    /// В тестировании
    /// </summary>
    Testing = 3,
    
    /// <summary>
    /// Ревью
    /// </summary>
    Review = 4,
    
    /// <summary>
    /// Работа над задачей приостановлена
    /// </summary>
    Paused = 5
}