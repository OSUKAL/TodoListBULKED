using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.Ticket;
using TodoListBULKED.App.Models.Ticket;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Handlers.Ticket;

/// <summary>
/// Обработчик создания задачи
/// </summary>
public class CreateTicketHandler
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ILogger<CreateTicketHandler> _logger;

    /// <inheritdoc cref="CreateTicketHandler"/>
    public CreateTicketHandler(ITicketRepository ticketRepository, ILogger<CreateTicketHandler> logger)
    {
        _ticketRepository = ticketRepository;
        _logger = logger;
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
            var actualUserId = UserIdSetter(request.UserId, userId);
            
            var ticket = new TicketModel
            {
                Id = Guid.NewGuid(),
                UserId = actualUserId,
                CreatorId = userId,
                State = TicketState.InProgress,
                Priority = request.Priority,
                Name = request.Name,
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

    private static Guid UserIdSetter(Guid requestUserId, Guid userId)
    {
        if (requestUserId == Guid.Empty)
            return userId;

        return requestUserId;
    }
}