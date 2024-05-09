using TodoLIstBULKED.Infrastructure.Enums;

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
    /// Идентификатор исполнителя
    /// </summary>
    public Guid UserId { get; init; }
    
    /// <summary>
    /// Идентификатор создателя
    /// </summary>
    public Guid CreatorId { get; init; }
    
    /// <summary>
    /// Состояние
    /// </summary>
    public TicketState State { get; init; }
    
    /// <summary>
    /// Приоритет
    /// </summary>
    public TicketPriority Priority { get; init; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Описание задачи
    /// </summary>
    public string Description { get; init; }
}


