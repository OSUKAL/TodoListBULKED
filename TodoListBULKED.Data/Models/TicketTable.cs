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
    /// Название
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// Уникальный номер
    /// </summary>
    public string Number { get; init; }

    /// <summary>
    /// Тип
    /// </summary>
    public int Type { get; internal set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Идентификатор создателя задачи
    /// </summary>
    public Guid CreatorId { get; init; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid PerformerId { get; internal set; }

    /// <summary>
    /// Состояние
    /// </summary>
    public int State { get; internal set; }

    /// <summary>
    /// Приоритет
    /// </summary>
    public int Priority { get; internal set; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    public string Description { get; internal set; }
}