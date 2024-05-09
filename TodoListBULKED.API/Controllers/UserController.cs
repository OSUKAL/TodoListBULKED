using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TodoListBULKED.App.Handlers.User;
using TodoListBULKED.App.Models.Requests.Auth;

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
            return BadRequest(validationResult.Errors[0].ToString());

        var result = await _createUserHandler.HandleAsync(request, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.Errors[0].ToString());

        return Ok();
    }
    
    private static Result ValidateCreateUserRequest(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Укажите имя пользователя");
        
        if (string.IsNullOrWhiteSpace(request.Password))
            return Result.Fail("Укажите пароль");

        return Result.Ok();
    }
}