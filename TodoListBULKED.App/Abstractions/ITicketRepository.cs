using TodoListBULKED.App.Models.Ticket;

namespace TodoListBULKED.App.Abstractions;

/// <summary>
/// Репозиторий для работы с таблицей задач
/// </summary>
public interface ITicketRepository
{
    /// <summary>
    /// Создание записи задачи
    /// </summary>
    /// <param name="ticket">Данные задачи</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task InsertAsync(TicketModel ticket, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех записей задач
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task<IReadOnlyCollection<TicketModel>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение записей задач исполнителя
    /// </summary>
    /// <param name="id">Идентификатор исполнителя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task<IReadOnlyCollection<TicketModel>> GetByPerformerIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Изменение записи задачи
    /// </summary>
    /// <param name="ticketEdit">Данные задачи</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task UpdateAsync(TicketEditModel ticketEdit, CancellationToken cancellationToken);
}