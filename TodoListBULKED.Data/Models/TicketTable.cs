using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListBULKED.Data.Models;

/// <summary>
/// Таблица задач
/// </summary>
[Table("tickets")]
public class TicketTable
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Column("id")]
    public Guid Id { get; init; }

    /// <summary>
    /// Название
    /// </summary>
    [Column("name", TypeName = "varchar(200)")]
    public string Name { get; internal set; }

    /// <summary>
    /// Номер
    /// </summary>
    [Column("number", TypeName = "varchar(12)")]
    public string Number { get; init; }

    /// <summary>
    /// Тип
    /// </summary>
    [Column("type")]
    public int Type { get; internal set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    [Column("creation_date")]
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Идентификатор создателя задачи
    /// </summary>
    [Column("creator_id")]
    public Guid CreatorId { get; init; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Column("performer_id")]
    public Guid PerformerId { get; internal set; }

    /// <summary>
    /// Состояние
    /// </summary>
    [Column("state")]
    public int State { get; internal set; }

    /// <summary>
    /// Приоритет
    /// </summary>
    [Column("priority")]
    public int Priority { get; internal set; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    [Column("description")]
    public string Description { get; internal set; }
}