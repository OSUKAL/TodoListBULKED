using System.Text.Json.Serialization;

namespace TodoListBULKED.App.Models.Responses.Ticket;

/// <summary>
/// Данные пользователя
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Имя</param>
public record TicketUserDto(
    [property: JsonPropertyName("id")] 
    Guid Id,
    [property: JsonPropertyName("name")] 
    string Name
);