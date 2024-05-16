namespace TodoListBULKED.App.Models.Ticket;

/// <summary>
/// Модель данных пользователя
/// </summary>
public class TicketUserModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; init; }
}