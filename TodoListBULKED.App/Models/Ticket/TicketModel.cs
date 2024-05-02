namespace TodoListBULKED.App.Models.Ticket;

/// <summary>
/// Модель данных задачи
/// </summary>
public class TicketModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; init; }
    
    /// <summary>
    /// Состояние
    /// </summary>
    public string State { get; init; }
    
    /// <summary>
    /// Приоритет
    /// </summary>
    public int Priority { get; init; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Описание задачи
    /// </summary>
    public string Description { get; init; }
}


