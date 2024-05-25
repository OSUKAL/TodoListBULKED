using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.User;

/// <summary>
/// Модель данных пользователя
/// </summary>
public class UserModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public UserRole Role { get; init; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Username { get; init; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string PasswordHash { get; init; }
}