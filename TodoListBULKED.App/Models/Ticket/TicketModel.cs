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
    /// Название
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Уникальный номер
    /// </summary>
    public string Number { get; init; }
    
    /// <summary>
    /// Тип
    /// </summary>
    public TicketType Type { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; init; }
    
    /// <summary>
    /// Идентификатор создателя
    /// </summary>
    public TicketUserModel Creator { get; init; }
    
    /// <summary>
    /// Идентификатор исполнителя
    /// </summary>
    public TicketUserModel Performer { get; init; }
    
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