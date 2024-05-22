using FluentResults;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.User;
using TodoListBULKED.App.Models.User;

namespace TodoListBULKED.App.Handlers.User;

/// <summary>
/// Обработчик изменения пользователя
/// </summary>
public class EditUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<EditUserHandler> _logger;

    /// <inheritdoc cref="EditUserHandler"/>
    public EditUserHandler(IUserRepository userRepository, ILogger<EditUserHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    /// <summary>
    /// Обработка изменения пользователя
    /// </summary>
    /// <param name="request">Запрос на изменение пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Result> HandleAsync(EditUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                return Result.Fail("Пользователь не найден");

            var userEdit = new UserEditModel
            {
                Id = request.Id,
                Role = request.Role,
                Username = request.Username
            };
            
            await _userRepository.UpdateAsync(userEdit, cancellationToken);
            
            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string ErrorText = "При изменении роли пользователя возникла ошибка";
            _logger.LogError(exception, ErrorText);

            return Result.Fail(ErrorText);
        }
    }
}