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
    public string Name { get; init; }

    /// <summary>
    /// Уникальный номер
    /// </summary>
    public string Number { get; init; }

    /// <summary>
    /// Тип
    /// </summary>
    public int Type { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid PerformerId { get; init; }

    /// <summary>
    /// Идентификатор создателя задачи
    /// </summary>
    public Guid CreatorId { get; init; }

    /// <summary>
    /// Состояние
    /// </summary>
    public int State { get; init; }

    /// <summary>
    /// Приоритет
    /// </summary>
    public int Priority { get; init; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    public string Description { get; init; }
}