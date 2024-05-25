using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.Requests.User;

/// <summary>
/// Запрос на изменение данных пользователя
/// </summary>
public class EditUserRequest
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    
    /// <summary>
    /// Роль
    /// </summary>
    [JsonPropertyName("role")]
    [EnumDataType(typeof(UserRole))]
    public UserRole Role { get; init; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; init; }
}