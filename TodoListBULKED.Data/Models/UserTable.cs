using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TodoListBULKED.Data.Models;

/// <summary>
/// Таблица пользователей
/// </summary>
[Index(nameof(Username), IsUnique = true)]
[Table("users")]
public class UserTable
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Column("id")]

    public Guid Id { get; init; }
    
    /// <summary>
    /// Роль
    /// </summary>
    [Column("role")]
    public int Role { get; internal set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Column("username", TypeName = "varchar(50)")]
    public string Username { get; internal set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [Column("password_hash")]
    public string PasswordHash { get; init; }
}