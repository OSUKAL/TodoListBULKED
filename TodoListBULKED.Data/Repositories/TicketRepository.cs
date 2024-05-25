using Microsoft.EntityFrameworkCore;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Ticket;
using TodoListBULKED.Data.Context;
using TodoListBULKED.Data.Models;
using TodoLIstBULKED.Infrastructure.Enums;

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
    public async Task InsertAsync(TicketModel ticket, CancellationToken cancellationToken)
    {
        //TODO ef core type cast
        
        _appDbContext.Tickets.Add(
            new TicketTable
            {
                Id = ticket.Id,
                Name = ticket.Name,
                Number = ticket.Number,
                Type = (int)ticket.Type,
                CreationDate = ticket.CreationDate,
                CreatorId = ticket.Creator.Id,
                PerformerId = ticket.Performer.Id,
                State = (int)ticket.State,
                Priority = (int)ticket.Priority,
                Description = ticket.Description
            });

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TicketModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var databaseTicket = await _appDbContext.Tickets
            .SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (databaseTicket == null)
            return null;

        return new TicketModel
        {
            Id = databaseTicket.Id,
            Name = databaseTicket.Name,
            Number = databaseTicket.Number,
            Type = (TicketType)databaseTicket.Type,
            CreationDate = databaseTicket.CreationDate,
            Creator = new TicketUserModel
            {
                Id = databaseTicket.CreatorId
            },
            Performer = new TicketUserModel
            {
                Id = databaseTicket.PerformerId
            },
            State = (TicketState)databaseTicket.State,
            Priority = (TicketPriority)databaseTicket.Priority,
            Description = databaseTicket.Description
        };
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<TicketModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var ticketsWithoutUsers = _appDbContext.Tickets;

        var tickets = await JoinUsersQuery(ticketsWithoutUsers)
            .ToArrayAsync(cancellationToken);
        
        return tickets;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<TicketModel>> GetByPerformerIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var ticketsWithoutUsers = _appDbContext.Tickets
            .Where(t => t.PerformerId == id);
            

        var tickets = await JoinUsersQuery(ticketsWithoutUsers)
            .ToArrayAsync(cancellationToken);
        
        return tickets;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<TicketModel>> GetByCreatorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var ticketsWithoutUsers = _appDbContext.Tickets
            .Where(t => t.CreatorId == id);

        var tickets = await JoinUsersQuery(ticketsWithoutUsers)
            .ToArrayAsync(cancellationToken);

        return tickets;
    }
    
    /// <inheritdoc/>
    public async Task UpdateAsync(TicketEditModel editedTicket, CancellationToken cancellationToken)
    {
        var databaseTicket = await _appDbContext.Tickets
            .SingleOrDefaultAsync(t => t.Id == editedTicket.Id, cancellationToken);
        if (databaseTicket == null)
            return;

        databaseTicket.Name = editedTicket.Name;
        databaseTicket.Type = (int)editedTicket.Type;
        databaseTicket.PerformerId = editedTicket.PerformerId;
        databaseTicket.State = (int)editedTicket.State;
        databaseTicket.Priority = (int)editedTicket.Priority;
        databaseTicket.Description = editedTicket.Description;

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    private IQueryable<TicketModel> JoinUsersQuery(IQueryable<TicketTable> tickets)
    {
        return tickets
            .Join(_appDbContext.Users,
                t => t.PerformerId,
                u => u.Id,
                (t, u) => new
                {
                    Ticket = t,
                    Performer = u
                })
            .Join(_appDbContext.Users,
                a => a.Ticket.CreatorId,
                u => u.Id,
                (a, u) => new TicketModel
                {
                    Id = a.Ticket.Id,
                    Name = a.Ticket.Name,
                    Number = a.Ticket.Number,
                    Type = (TicketType)a.Ticket.Type,
                    CreationDate = a.Ticket.CreationDate,
                    Creator = new TicketUserModel
                    {
                        Id = u.Id,
                        Name = u.Username
                    },
                    Performer = new TicketUserModel
                    {
                        Id = a.Performer.Id,
                        Name = a.Performer.Username
                    },
                    State = (TicketState)a.Ticket.State,
                    Priority = (TicketPriority)a.Ticket.Priority,
                    Description = a.Ticket.Description
                });
    }
}