using Microsoft.EntityFrameworkCore;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.User;
using TodoListBULKED.Data.Context;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.Data.Repositories;

/// <inheritdoc /> 
public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _appDbContext;

    /// <inheritdoc cref="AuthRepository"/> 
    public AuthRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc /> 
    public async Task<UserModel?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var databaseUser =  await _appDbContext.Users.SingleOrDefaultAsync(u => u.Username == username, cancellationToken);
        
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
}