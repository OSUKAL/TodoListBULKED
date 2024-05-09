using System.Text.Json.Serialization;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.Requests.Ticket;

/// <summary>
/// Запрос на создание задачи
/// </summary>
public class CreateTicketRequest
{
    /// <summary>
    /// Приоритет
    /// </summary>
    [JsonPropertyName("priority")]
    public TicketPriority Priority { get; init; }
    
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    [JsonPropertyName("userId")]
    public Guid UserId { get; init; }
    
    /// <summary>
    /// Название
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    /// <summary>
    /// Описание задачи
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; init; }
}