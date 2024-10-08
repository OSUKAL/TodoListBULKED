﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.Requests.User;

/// <summary>
/// Запрос на создание пользователя
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; init; }
    
    /// <summary>
    /// Роль
    /// </summary>
    [JsonPropertyName("role")]
    [EnumDataType(typeof(UserRole))]
    public UserRole Role { get; init; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; init; }
}