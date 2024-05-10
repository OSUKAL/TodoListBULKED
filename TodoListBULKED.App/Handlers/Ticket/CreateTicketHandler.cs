using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.Ticket;
using TodoListBULKED.App.Models.Ticket;
using TodoLIstBULKED.Infrastructure.Enums;
using TodoLIstBULKED.Infrastructure.Providers;

namespace TodoListBULKED.App.Handlers.Ticket;

/// <summary>
/// Обработчик создания задачи
/// </summary>
public class CreateTicketHandler
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ILogger<CreateTicketHandler> _logger;
    private readonly TimeProvider _timeProvider;
    private readonly EnumDescriptionProvider _enumDescriptionProvider;

    /// <inheritdoc cref="CreateTicketHandler"/>
    public CreateTicketHandler(ITicketRepository ticketRepository, ILogger<CreateTicketHandler> logger, TimeProvider timeProvider, EnumDescriptionProvider enumDescriptionProvider)
    {
        _ticketRepository = ticketRepository;
        _logger = logger;
        _timeProvider = timeProvider;
        _enumDescriptionProvider = enumDescriptionProvider;
    }

    /// <summary>
    /// Обработка создания задачи
    /// </summary>
    /// <param name="request">Запрос на создание задачи</param>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Result> HandleAsync(CreateTicketRequest request, Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var dateNow = _timeProvider.GetUtcNow().UtcDateTime;
            var performerId = GetPerformerId(request.PerformerId, userId);
            var ticketNumber = GetTicketNumber(request.Type, dateNow);
            
            var ticket = new TicketModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Number = ticketNumber,
                Type = request.Type,
                CreationDate = dateNow,
                PerformerId = performerId,
                CreatorId = userId,
                State = TicketState.InProgress,
                Priority = request.Priority,
                Description = request.Description
            };

            await _ticketRepository.InsertAsync(ticket, cancellationToken);

            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string ErrorText = "При создании задачи возникла ошибка";
            _logger.LogError(exception, ErrorText);

            return Result.Fail(ErrorText);
        }
    }

    private static Guid GetPerformerId(Guid requestUserId, Guid userId)
    {
        if (requestUserId == Guid.Empty)
            return userId;

        return requestUserId;
    }

    private string GetTicketNumber(TicketType type, DateTime date)
    {
        var number = date.ToString("yyMMddHHmmss");
        var description = _enumDescriptionProvider.GetDescription(type);
        var result = $"{description}-{number}";

        return result;
    }
}