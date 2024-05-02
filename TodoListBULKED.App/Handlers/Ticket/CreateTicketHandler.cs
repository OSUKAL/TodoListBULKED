using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.Ticket;
using TodoListBULKED.App.Models.Ticket;

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

    public async Task<Result> HandleAsync(CreateTicketRequest request, Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var ticket = new TicketModel
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                State = "In progress",
                Priority = request.Priority,
                Name = request.Name,
                Description = request.Description
            };

            await _ticketRepository.InsertAsync(ticket, cancellationToken);

            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string errorText = "При создании задачи возникла ошибка";
            _logger.LogError(exception, errorText);

            return Result.Fail(errorText);
        }
    }
}