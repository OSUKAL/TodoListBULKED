using System.ComponentModel;

namespace TodoLIstBULKED.Infrastructure.Enums;

/// <summary>
/// Тип задачи
/// </summary>
public enum TicketType
{
    /// <summary>
    /// Неизвестная
    /// </summary>
    [Description("Н")]
    Unknown = 0,
    
    /// <summary>
    /// Тестирование
    /// </summary>
    [Description("Т")]
    Test = 1,
    
    /// <summary>
    /// Разработка
    /// </summary>
    [Description("Р")]
    Development = 2,
    
    /// <summary>
    /// Исследование
    /// </summary>
    [Description("И")]
    Research = 3,
    
    /// <summary>
    /// Исправление ошибки
    /// </summary>
    [Description("ИО")]
    Fix = 4
}