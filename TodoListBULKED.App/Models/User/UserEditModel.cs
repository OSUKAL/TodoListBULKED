using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.User;

/// <summary>
/// Модель изменений пользователя
/// </summary>
public class UserEditModel
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
}