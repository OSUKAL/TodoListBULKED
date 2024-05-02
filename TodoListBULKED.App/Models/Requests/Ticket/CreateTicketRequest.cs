using System.Text.Json.Serialization;

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
    public int Priority { get; init; }
    
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