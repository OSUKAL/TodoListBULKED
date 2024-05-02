namespace TodoListBULKED.Data.Models;

/// <summary>
/// Таблица пользователей
/// </summary>
public class UserTable
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Username { get; init; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; init; }
}