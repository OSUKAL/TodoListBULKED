using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.Auth;
using TodoListBULKED.App.Models.User;
using TodoLIstBULKED.Infrastructure.Hashers;

namespace TodoListBULKED.App.Handlers.User;

/// <summary>
/// Обработчик создания пользователя
/// </summary>
public class CreateUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreateUserHandler> _logger;
    private readonly IHasher _hasher;

    /// <inheritdoc cref="CreateUserHandler"/> 
    public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger, IHasher hasher)
    {
        _userRepository = userRepository;
        _logger = logger;
        _hasher = hasher;
    }

    /// <summary>
    /// Обработка создания пользователя
    /// </summary>
    /// <param name="request">Запрос на создание пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Result> HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = await ValidateCreateUserRequest(request, cancellationToken);
            if (validationResult.IsFailed)
                return validationResult;
            
            var hashedPassword = _hasher.Hash(request.Password);
            
            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                Role = request.Role,
                Username = request.Username,
                PasswordHash = hashedPassword
            };

            await _userRepository.InsertAsync(user, cancellationToken);

            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string ErrorText = "При создании пользователя возникла ошибка";
            _logger.LogError(exception, ErrorText);

            return Result.Fail(ErrorText);
        }
    }

    private async Task<Result> ValidateCreateUserRequest(CreateUserRequest request, CancellationToken cancellationToken)
    {
        //TODO дописать валидацию запроса на создание пользователя
        
        var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
        if (user != null)
            return Result.Fail("Пользователь с таким именем уже существует");

        return Result.Ok();
    }
}