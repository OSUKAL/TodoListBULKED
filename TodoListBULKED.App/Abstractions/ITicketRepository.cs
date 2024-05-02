using TodoListBULKED.App.Models;
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
    /// <param name="ticketModel">Данные задачи</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task InsertAsync(TicketModel ticketModel, CancellationToken cancellationToken);

    /// <summary>
    /// Получение записи задачи по идентификатору пользователя
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task<TicketModel?> GetByUserIdAsync(Guid id, CancellationToken cancellationToken);
}