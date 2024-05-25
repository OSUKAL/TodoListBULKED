using Microsoft.Extensions.Configuration;

namespace TodoListBULKED.Data.Configuration;

/// <summary>
/// Конфигурация подключение к базе данных
/// </summary>
public class DatabaseConfig
{
    /// <summary>
    /// Адрес для подключения
    /// </summary>
    [ConfigurationKeyName("Host")]
    public string Host { get; init; }

    /// <summary>
    /// Порт
    /// </summary>
    [ConfigurationKeyName("Port")]
    public int Port { get; init; }
    
    /// <summary>
    /// Название базы данных
    /// </summary>
    [ConfigurationKeyName("Database")]
    public string Database { get; init; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [ConfigurationKeyName("Username")]
    public string Username { get; init; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [ConfigurationKeyName("Password")]
    public string Password { get; init; }
}