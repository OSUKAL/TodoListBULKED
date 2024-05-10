using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Ticket;
using TodoListBULKED.Data.Context;
using TodoListBULKED.Data.Models;

namespace TodoListBULKED.Data.Repositories;

/// <inheritdoc/>
public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _appDbContext;

    /// <inheritdoc cref="TicketRepository"/>
    public TicketRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc/>
    public async Task InsertAsync(TicketModel ticketModel, CancellationToken cancellationToken)
    {
        //TODO ef core type cast
        
        _appDbContext.Tickets.Add(
            new TicketTable
            {
                Id = ticketModel.Id,
                Name = ticketModel.Name,
                Number = ticketModel.Number,
                Type = (int)ticketModel.Type,
                CreationDate = ticketModel.CreationDate,
                PerformerId = ticketModel.PerformerId,
                CreatorId = ticketModel.CreatorId,
                State = (int)ticketModel.State,
                Priority = (int)ticketModel.Priority,
                Description = ticketModel.Description
            });

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TicketModel?> GetByUserIdAsync(Guid id, CancellationToken cancellationToken)
    {
        ///
        
        return new TicketModel();
    }
}