using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TodoListBULKED.App.Handlers.User;
using TodoListBULKED.App.Models.Requests.Auth;
using TodoLIstBULKED.Infrastructure.Enums;
using TodoLIstBULKED.Infrastructure.Extensions;

namespace TodoListBULKED.API.Controllers;

/// <summary>
/// Контроллер для работы с пользователями
/// </summary>
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly CreateUserHandler _createUserHandler;

    /// <inheritdoc cref="AuthController"/>
    public UserController(CreateUserHandler createUserHandler)
    {
        _createUserHandler = createUserHandler;
    }
    
    /// <summary>
    /// Создание пользователя
    /// </summary>
    /// <param name="request">Запрос на создание пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpPost("create")]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var validationResult = ValidateCreateUserRequest(request);
        if (validationResult.IsFailed)
            return BadRequest(validationResult.ErrorSummary());

        var result = await _createUserHandler.HandleAsync(request, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.ErrorSummary());

        return Ok();
    }
    
    private static Result ValidateCreateUserRequest(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Укажите имя пользователя");

        if (request.Role == UserRole.Unknown)
            return Result.Fail("Укажите роль пользователя");
        
        if (string.IsNullOrWhiteSpace(request.Password))
            return Result.Fail("Укажите пароль");

        return Result.Ok();
    }
}