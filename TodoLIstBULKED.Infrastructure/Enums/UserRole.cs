namespace TodoLIstBULKED.Infrastructure.Enums;

/// <summary>
/// Роль пользователя
/// </summary>
public enum UserRole
{
    /// <summary>
    /// Неизвестная
    /// </summary>
    Unknown = 0,
    
    /// <summary>
    /// Руководитель команды
    /// </summary>
    TeamLeader = 1,
    
    /// <summary>
    /// Разработчик
    /// </summary>
    Developer = 2,
    
    /// <summary>
    /// Тестировщик
    /// </summary>
    Tester = 3,
    
    /// <summary>
    /// )))
    /// </summary>
    Analyst = 4
}