using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.Requests.Ticket;

/// <summary>
/// Запрос на изменение данных задачи
/// </summary>
public class EditTicketRequest
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    /// <summary>
    /// Название
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    /// <summary>
    /// Тип
    /// </summary>
    [JsonPropertyName("type")]
    [EnumDataType(typeof(TicketType))]
    public TicketType Type { get; init; }
    
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    [JsonPropertyName("performerId")]
    public Guid PerformerId { get; init; }
    
    /// <summary>
    /// Состояние
    /// </summary>
    [JsonPropertyName("state")]
    [EnumDataType(typeof(TicketState))]
    public TicketState State { get; init; }
    
    /// <summary>
    /// Приоритет
    /// </summary>
    [JsonPropertyName("priority")]
    [EnumDataType(typeof(TicketPriority))]
    public TicketPriority Priority { get; init; }
    
    /// <summary>
    /// Описание задачи
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; init; }
}