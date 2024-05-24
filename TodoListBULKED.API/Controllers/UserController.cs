using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListBULKED.App.Handlers.User;
using TodoListBULKED.App.Models.Requests.User;
using TodoLIstBULKED.Infrastructure.Authorization;
using TodoLIstBULKED.Infrastructure.Enums;
using TodoLIstBULKED.Infrastructure.Extensions;

namespace TodoListBULKED.API.Controllers;

/// <summary>
/// Контроллер для работы с пользователями
/// </summary>
[ApiController]
[Route("api/user")]
[Authorize(Policy = AuthPolicyConstants.AdminOnly)]
public class UserController : ControllerBase
{
    private readonly CreateUserHandler _createUserHandler;
    private readonly EditUserHandler _editUserHandler;

    /// <inheritdoc cref="AuthController"/>
    public UserController(CreateUserHandler createUserHandler, EditUserHandler editUserHandler)
    {
        _createUserHandler = createUserHandler;
        _editUserHandler = editUserHandler;
    }
    
    /// <summary>
    /// Создание пользователя
    /// </summary>
    /// <param name="request">Запрос на создание пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var validationResult = ValidateCreateUserRequest(request);
        if (validationResult.IsFailed)
            return BadRequest(validationResult.ErrorSummary());

        var result = await _createUserHandler.HandleAsync(request, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.ErrorSummary());

        return Ok();
    }

    /// <summary>
    /// Редактирование пользователя
    /// </summary>
    /// <param name="request">Запрос на редактирование пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpPost("edit")]
    public async Task<IActionResult> EditAsync([FromBody] EditUserRequest request, CancellationToken cancellationToken)
    {
        var validationResult = ValidateEditUserRequest(request);
        if (validationResult.IsFailed)
            return BadRequest(validationResult.ErrorSummary());
        
        var result = await _editUserHandler.HandleAsync(request, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.ErrorSummary());
        
        return Ok();
    }
    
    private static Result ValidateCreateUserRequest(CreateUserRequest request)
    {
        if (request.Role == UserRole.Unknown)
            return Result.Fail("Укажите роль пользователя");
        
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Укажите имя пользователя");
        
        if (string.IsNullOrWhiteSpace(request.Password))
            return Result.Fail("Укажите пароль");

        return Result.Ok();
    }

    private static Result ValidateEditUserRequest(EditUserRequest request)
    {
        if (request.Id == Guid.Empty)
            return Result.Fail("Пользователь не указан");
        
        if (request.Role == UserRole.Unknown)
            return Result.Fail("Укажите роль пользователя");
        
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Укажите имя пользователя");

        return Result.Ok();
    }
}