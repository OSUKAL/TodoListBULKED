using System.Text.Json.Serialization;

namespace TodoListBULKED.App.Models.Responses.Ticket;

/// <summary>
/// Ответ на запрос получения задач
/// </summary>
/// <param name="Tickets">Задачи</param>
public record GetTicketsResponse(
    [property: JsonPropertyName("tickets")] 
    IReadOnlyCollection<TicketDto> Tickets
);