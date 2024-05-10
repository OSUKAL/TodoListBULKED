namespace TodoLIstBULKED.Infrastructure.Enums;

/// <summary>
/// Приоритет задачи
/// </summary>
public enum TicketPriority
{
    /// <summary>
    /// Неизвестный
    /// </summary>
    Unknown = 0,
    
    /// <summary>
    /// Наивысший
    /// </summary>
    TopLevelPriority = 1,
    
    /// <summary>
    /// Высокий
    /// </summary>
    HighLevelPriority = 2,
    
    /// <summary>
    /// Средний
    /// </summary>
    MidLevelPriority = 3,
    
    /// <summary>
    /// Низкий
    /// </summary>
    LowLevelPriority = 4
}