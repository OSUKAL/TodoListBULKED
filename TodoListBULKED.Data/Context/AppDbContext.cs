using Microsoft.EntityFrameworkCore;
using TodoListBULKED.Data.Models;

namespace TodoListBULKED.Data.Context;

/// <summary>
/// Контекст базы данных
/// </summary>
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    /// <summary>
    /// Таблица пользователей
    /// </summary>
    public DbSet<UserTable> Users => Set<UserTable>();

    /// <summary>
    /// Таблица задач
    /// </summary>
    public DbSet<TicketTable> Tickets => Set<TicketTable>();
}