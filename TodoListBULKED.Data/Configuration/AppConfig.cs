using Microsoft.Extensions.Configuration;

namespace TodoListBULKED.Data.Configuration;

/// <summary>
/// Конфигурация приложения
/// </summary>
public class AppConfig
{
    /// <summary>
    /// Конфигурация подключения к базе данных
    /// </summary>
    [ConfigurationKeyName("DatabaseConfig")]
    public DatabaseConfig DatabaseConfig { get; init; }
}