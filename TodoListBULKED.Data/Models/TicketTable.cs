using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.Data.Models;

/// <summary>
/// Таблица задач
/// </summary>
public class TicketTable
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
    /// Идентификатор создателя задачи
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