using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListBULKED.App.Handlers;
using TodoListBULKED.App.Handlers.Auth;
using TodoListBULKED.App.Models.Requests;
using TodoListBULKED.App.Models.Requests.Auth;

namespace TodoListBULKED.API.Controllers;

/// <summary>
/// Контроллер авторизации
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly CreateUserHandler _createUserHandler;
    private readonly LoginHandler _loginHandler;
    private readonly LogoutHandler _logoutHandler;

    /// <inheritdoc cref="AuthController"/>
    public AuthController(CreateUserHandler createUserHandler, LoginHandler loginHandler, LogoutHandler logoutHandler)
    {
        _createUserHandler = createUserHandler;
        _loginHandler = loginHandler;
        _logoutHandler = logoutHandler;
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

    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    /// <param name="request">Запрос на авторизацию</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpPost("login")]
    public async Task<IActionResult> LogInAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var validationResult = ValidateLoginRequest(request);
        if (validationResult.IsFailed)
            return BadRequest(validationResult.Errors[0].ToString());
            
        var result = await _loginHandler.HandleAsync(request, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.Errors[0].ToString());

        return Ok();
    }

    /// <summary>
    /// Выход из аккаунта
    /// </summary>
    [Authorize]
    [HttpGet("logout")]
    public async Task<IActionResult> LogOutAsync()
    {
        var result = await _logoutHandler.HandleAsync();
        if (result.IsFailed)
            return BadRequest(result.Errors[0].ToString());

        return Ok();
    }

    private Result ValidateCreateUserRequest(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Укажите имя пользователя");
        
        if (string.IsNullOrWhiteSpace(request.Password))
            return Result.Fail("Укажите пароль");

        return Result.Ok();
    }
    
    private Result ValidateLoginRequest(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Введите имя пользователя");
        
        if (string.IsNullOrWhiteSpace(request.Password))
            return Result.Fail("Введите пароль");

        return Result.Ok();
    }
}