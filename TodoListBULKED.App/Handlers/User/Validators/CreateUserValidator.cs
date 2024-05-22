using FluentResults;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.User;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Handlers.User.Validators;

/// <summary>
/// Валидатор создания пользователя
/// </summary>
public class CreateUserValidator
{
    private readonly IUserRepository _userRepository;

    /// <inheritdoc cref="CreateUserValidator"/>
    public CreateUserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Валидация запроса на создание пользователя
    /// </summary>
    /// <param name="request">Запрос на создание пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Result> ValidateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (request.Username.Length < 2)
            return Result.Fail("Слишком короткое имя пользователя");
        
        if (request.Role == UserRole.Unknown)
            return Result.Fail("Не указана роль пользователя");

        if (request.Password.Length < 9)
            return Result.Fail("Слишком короткий пароль");
        
        var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
        if (user != null)
            return Result.Fail("Пользователь с таким именем уже существует");

        return Result.Ok();
    }
}