using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Responses.Ticket;
using TodoLIstBULKED.Infrastructure.Enums;
using TodoLIstBULKED.Infrastructure.Providers;

namespace TodoListBULKED.App.Handlers.Ticket;

/// <summary>
/// Обработчик получения всех задач
/// </summary>
public class GetTicketsHandler
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ILogger<GetTicketsHandler> _logger;
    private readonly EnumDescriptionProvider _enumDescriptionProvider;
    
    /// <inheritdoc cref="GetTicketsHandler"/>
    public GetTicketsHandler(ITicketRepository ticketRepository, ILogger<GetTicketsHandler> logger, EnumDescriptionProvider enumDescriptionProvider)
    {
        _ticketRepository = ticketRepository;
        _logger = logger;
        _enumDescriptionProvider = enumDescriptionProvider;
    }

    /// <summary>
    /// Обработка получения всех задач
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Result<GetTicketsResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        try
        {
            var tickets = await _ticketRepository.GetAllAsync(cancellationToken);

            var ticketDtos = tickets
                .Select(t => new TicketDto(
                    t.Id,
                    t.Name,
                    GetPrefixedTicketNumber(t.Type, t.Number),
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
            const string ErrorText = "При получении задач возникла ошибка";
            _logger.LogError(exception, ErrorText);

            return Result.Fail(ErrorText);
        }
    }

    private string GetPrefixedTicketNumber(TicketType type, string number)
    {
        var description = _enumDescriptionProvider.GetDescription(type);
        var result = $"{description}-{number}";

        return result;
    }
}