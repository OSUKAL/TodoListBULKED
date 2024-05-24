using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.Ticket;
using TodoListBULKED.App.Models.Ticket;

namespace TodoListBULKED.App.Handlers.Ticket;

/// <summary>
/// Обработчик изменения задачи
/// </summary>
public class EditTicketHandler
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ILogger<EditTicketHandler> _logger;

    /// <inheritdoc cref="EditTicketHandler"/>
    public EditTicketHandler(ITicketRepository ticketRepository, ILogger<EditTicketHandler> logger)
    {
        _ticketRepository = ticketRepository;
        _logger = logger;
    }

    /// <summary>
    /// Обработка изменения задачи
    /// </summary>
    /// <param name="request">Запрос на изменение задачи</param>
    /// <param name="userId">Идентификатор пользотвателя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Result> HandleAsync(EditTicketRequest request, Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.Id, cancellationToken);
            if (ticket == null)
                return Result.Fail("Задача не найдена");

            if (ticket.Creator.Id != userId)
                return Result.Fail("Вы не можете редактировать эту задачу");
            
            var ticketEdit = new TicketEditModel
            {
                Id = request.Id,
                Name = request.Name,
                Type = request.Type,
                PerformerId = request.PerformerId,
                State = request.State,
                Priority = request.Priority,
                Description = request.Description
            };
            
            await _ticketRepository.UpdateAsync(ticketEdit, cancellationToken);
            
            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string ErrorText = "При изменении задачи возникла ошибка";
            _logger.LogError(exception, ErrorText);

            return Result.Fail(ErrorText);
        }
    }
}