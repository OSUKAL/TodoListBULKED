using Microsoft.EntityFrameworkCore;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.User;
using TodoListBULKED.Data.Context;
using TodoListBULKED.Data.Models;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.Data.Repositories;

/// <inheritdoc />
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    /// <inheritdoc cref="UserRepository"/>
    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc />
    public async Task InsertAsync(UserModel userModel, CancellationToken cancellationToken)
    {
        _appDbContext.Users.Add(
            new UserTable
            {
                Id = userModel.Id,
                Role = (int)userModel.Role,
                Username = userModel.Username,
                PasswordHash = userModel.PasswordHash
            });

        await _appDbContext.SaveChangesAsync(cancellationToken);
    }
    
    /// <inheritdoc/>
    public async Task<UserModel?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var databaseUser = await _appDbContext.Users
            .SingleOrDefaultAsync(u => u.Username == username, cancellationToken);
        if (databaseUser == null)
            return null;

        return new UserModel
        {
            Id = databaseUser.Id,
            Role = (UserRole)databaseUser.Role,
            Username = databaseUser.Username,
            PasswordHash = databaseUser.PasswordHash
        };
    }

    /// <inheritdoc/>
    public async Task<UserModel?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var databaseUser = await _appDbContext.Users
            .SingleOrDefaultAsync(u => u.Id == userId, cancellationToken);
        if (databaseUser == null)
            return null;

        return new UserModel
        {
            Id = databaseUser.Id,
            Role = (UserRole)databaseUser.Role,
            Username = databaseUser.Username,
            PasswordHash = databaseUser.PasswordHash
        };
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(UserEditModel editedUser, CancellationToken cancellationToken)
    {
        var databaseUser = await _appDbContext.Users
            .SingleOrDefaultAsync(u => u.Id == editedUser.Id, cancellationToken);
        if(databaseUser == null)
            return;

        databaseUser.Role = (int)editedUser.Role;
        databaseUser.Username = editedUser.Username;
        
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}