using System.Runtime.InteropServices;

namespace TodoLIstBULKED.Inrastructure.Enums;

/// <summary>
/// Состояние задачи
/// </summary>
public enum TicketState
{
    /// <summary>
    /// Неизвестное состояние
    /// </summary>
    Unknown = 0,
    
    /// <summary>
    /// Задача в работе
    /// </summary>
    InProgress = 1,
    
    /// <summary>
    /// Задача выполнена
    /// </summary>
    Done = 2
}