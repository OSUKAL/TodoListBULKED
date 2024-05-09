﻿using Microsoft.EntityFrameworkCore;
using TodoLIstBULKED.Infrastructure.Enums;

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
    public UserRole Role { get; init; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Username { get; init; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; init; }
}