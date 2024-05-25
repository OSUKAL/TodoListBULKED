using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Responses.Ticket;
using TodoListBULKED.App.Utilities;

namespace TodoListBULKED.App.Handlers.Ticket;

/// <summary>
/// Обработчик получения задач создателя
/// </summary>
public class GetCreatorTicketsHandler
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ILogger<GetCreatorTicketsHandler> _logger;
    private readonly TicketNumberUtility _ticketNumberUtility;

    /// <inheritdoc cref="GetCreatorTicketsHandler"/>
    public GetCreatorTicketsHandler(ITicketRepository ticketRepository, ILogger<GetCreatorTicketsHandler> logger, TicketNumberUtility ticketNumberUtility)
    {
        _ticketRepository = ticketRepository;
        _logger = logger;
        _ticketNumberUtility = ticketNumberUtility;
    }

    /// <summary>
    /// Обработка получения задач создателя
    /// </summary>
    /// <param name="id">Идентификатор создателя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Result<GetTicketsResponse>> HandleAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var tickets = await _ticketRepository.GetByCreatorIdAsync(id, cancellationToken);

            var ticketDtos = tickets
                .Select(t => new TicketDto(
                    t.Id,
                    t.Name,
                    _ticketNumberUtility.AddTypePrefix(t.Type, t.Number),
                    t.Type,
                    t.CreationDate,
                    new TicketUserDto(t.Creator.Id, t.Creator.Name ?? string.Empty),
                    new TicketUserDto(t.Performer.Id, t.Performer.Name ?? string.Empty),
                    t.State,
                    t.Priority,
                    t.Description
                ))
                .ToArray();

            return new GetTicketsResponse(ticketDtos);
        }
        catch (Exception exception)
        {
            const string ErrorText = "При получении задач создателя возникла ошибка";
            _logger.LogError(exception, ErrorText);

            return Result.Fail(ErrorText);
        }
    }
}