using Microsoft.EntityFrameworkCore;

namespace TodoListBULKED.Data.Models;

/// <summary>
/// Таблица пользователей
/// </summary>
[PrimaryKey(nameof(Id), nameof(Username))]
[Index(nameof(Username), IsUnique = true)]
public class UserTable
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public int Role { get; internal set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Username { get; internal set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string PasswordHash { get; init; }
}