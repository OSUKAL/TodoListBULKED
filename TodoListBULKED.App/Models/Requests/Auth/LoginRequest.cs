using System.Text.Json.Serialization;

namespace TodoListBULKED.App.Models.Requests.Auth;

/// <summary>
/// Запрос на авторизацию
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; init; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; init; }
}