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
    Top = 1,
    
    /// <summary>
    /// Высокий
    /// </summary>
    High = 2,
    
    /// <summary>
    /// Средний
    /// </summary>
    Mid = 3,
    
    /// <summary>
    /// Низкий
    /// </summary>
    Low = 4
}