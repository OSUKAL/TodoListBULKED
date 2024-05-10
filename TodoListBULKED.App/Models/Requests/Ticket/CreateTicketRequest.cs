using System.Text.Json.Serialization;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.Requests.Ticket;

/// <summary>
/// Запрос на создание задачи
/// </summary>
public class CreateTicketRequest
{
    /// <summary>
    /// Название
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    /// <summary>
    /// Тип
    /// </summary>
    [JsonPropertyName("type")]
    public TicketType Type { get; init; }
    
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    [JsonPropertyName("performerId")]
    public Guid PerformerId { get; init; }
    
    /// <summary>
    /// Приоритет
    /// </summary>
    [JsonPropertyName("priority")]
    public TicketPriority Priority { get; init; }
    
    /// <summary>
    /// Описание задачи
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; init; }
}