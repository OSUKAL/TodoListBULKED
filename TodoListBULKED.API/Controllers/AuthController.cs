using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListBULKED.App.Handlers.Auth;
using TodoListBULKED.App.Models.Requests.Auth;
using TodoLIstBULKED.Infrastructure.Extensions;

namespace TodoListBULKED.API.Controllers;

/// <summary>
/// Контроллер авторизации
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly LoginHandler _loginHandler;
    private readonly LogoutHandler _logoutHandler;

    /// <inheritdoc cref="AuthController"/>
    public AuthController(LoginHandler loginHandler, LogoutHandler logoutHandler)
    {
        _loginHandler = loginHandler;
        _logoutHandler = logoutHandler;
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
            return BadRequest(validationResult.ErrorSummary());
            
        var result = await _loginHandler.HandleAsync(request, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.ErrorSummary());

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
            return BadRequest(result.ErrorSummary());

        return Ok();
    }
    
    private static Result ValidateLoginRequest(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Введите имя пользователя");
        
        if (string.IsNullOrWhiteSpace(request.Password))
            return Result.Fail("Введите пароль");

        return Result.Ok();
    }
}