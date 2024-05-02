using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models;
using TodoListBULKED.App.Models.Requests.Auth;
using TodoListBULKED.App.Models.User;

namespace TodoListBULKED.App.Handlers.Auth;

/// <summary>
/// Обработчик создания пользователя
/// </summary>
public class CreateUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreateUserHandler> _logger;

    /// <inheritdoc cref="CreateUserHandler"/> 
    public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    /// <summary>
    /// Обработка создания пользователя
    /// </summary>
    /// <param name="request">Запрос на создание пользователя</param>
    /// <param name="cancellationToken">Токен омтены операции</param>
    public async Task<Result> HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = request.Password
            };

            await _userRepository.InsertAsync(user, cancellationToken);

            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string errorText = "При создании пользователя возникла ошибка";
            _logger.LogError(exception, errorText);

            return Result.Fail(errorText);
        }
    }
}