using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.Ticket;

/// <summary>
/// Модель изменений задачи
/// </summary>
public class TicketEditModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Тип
    /// </summary>
    public TicketType Type { get; init; }
    
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    public Guid PerformerId { get; init; }
    
    /// <summary>
    /// Состояние
    /// </summary>
    public TicketState State { get; init; }
    
    /// <summary>
    /// Приоритет
    /// </summary>
    public TicketPriority Priority { get; init; }
    
    /// <summary>
    /// Описание задачи
    /// </summary>
    public string Description { get; init; }
}