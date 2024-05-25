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
    /// Администратор
    /// </summary>
    Admin = 1,
    
    /// <summary>
    /// Руководитель команды
    /// </summary>
    TeamLeader = 2,
    
    /// <summary>
    /// Разработчик
    /// </summary>
    Developer = 3,
    
    /// <summary>
    /// Тестировщик
    /// </summary>
    Tester = 4,
    
    /// <summary>
    /// Аналитик
    /// </summary>
    Analyst = 5
}