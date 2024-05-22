using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Handlers.User.Validators;
using TodoListBULKED.App.Models.Requests.User;
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
    private readonly CreateUserValidator _createUserValidator;

    /// <inheritdoc cref="CreateUserHandler"/> 
    public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger, IHasher hasher, CreateUserValidator createUserValidator)
    {
        _userRepository = userRepository;
        _logger = logger;
        _hasher = hasher;
        _createUserValidator = createUserValidator;
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
            var validationResult = await _createUserValidator.ValidateAsync(request, cancellationToken);
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
}