using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TodoListBULKED.App.Handlers.Ticket;
using TodoListBULKED.App.Models.Requests.Ticket;
using TodoLIstBULKED.Infrastructure.Cookie;
using TodoLIstBULKED.Infrastructure.Cookie.Constants;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.API.Controllers;

/// <summary>
/// Контроллер для работы с задачами
/// </summary>
[ApiController]
[Route("api/ticket")]
public class TicketController : ControllerBase
{
    private readonly CreateTicketHandler _createTicketHandler;
    private readonly ICookieGetter _cookieGetter;
    private readonly GetTicketsHandler _getTicketsHandler;
    private readonly GetPerformerTicketsHandler _getPerformerTicketsHandler;
    private readonly EditTicketHandler _editTicketHandler;
    
    /// <inheritdoc cref="TicketController"/>
    public TicketController(CreateTicketHandler createTicketHandler,
        ICookieGetter cookieGetter,
        GetTicketsHandler getTicketsHandler,
        GetPerformerTicketsHandler getPerformerTicketsHandler,
        EditTicketHandler editTicketHandler)
    {
        _createTicketHandler = createTicketHandler;
        _cookieGetter = cookieGetter;
        _getTicketsHandler = getTicketsHandler;
        _getPerformerTicketsHandler = getPerformerTicketsHandler;
        _editTicketHandler = editTicketHandler;
    }

    /// <summary>
    /// Создание задачи
    /// </summary>
    /// <param name="request">Запрос на создание задачи</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var validationResult = ValidateCreateTicketRequest(request);
        if (validationResult.IsFailed)
            return BadRequest(validationResult.Errors[0].ToString());
        
        var userIdResult = _cookieGetter.GetValueFromCookie(CookieClaimConstants.UserId);
        var userId = Guid.Parse(userIdResult.Value);

        var result = await _createTicketHandler.HandleAsync(request, userId, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.Errors[0].ToString());

        return Ok();
    }

    /// <summary>
    /// Получение всех задач
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpGet("get/all")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _getTicketsHandler.HandleAsync(cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.Errors[0].ToString());
        
        return Ok(result.Value);
    }

    /// <summary>
    /// Получение задач исполнителя
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpGet("get/performer")]
    public async Task<IActionResult> GetPerformerTicketsAsync(CancellationToken cancellationToken)
    {
        var userIdResult = _cookieGetter.GetValueFromCookie(CookieClaimConstants.UserId);
        var userId = Guid.Parse(userIdResult.Value);

        var result = await _getPerformerTicketsHandler.HandleAsync(userId, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.Errors[0].ToString());

        return Ok(result.Value);
    }

    /// <summary>
    /// Редактирование задачи
    /// </summary>
    /// <param name="request">Запрос на редактирование задачи</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpPost("edit")]
    public async Task<IActionResult> EditTicketAsync([FromBody] EditTicketRequest request, CancellationToken cancellationToken)
    {
        var result = await _editTicketHandler.HandleAsync(request, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.Errors[0].ToString());
        
        return Ok();
    }

    private static Result ValidateCreateTicketRequest(CreateTicketRequest request)
    {
        if (request.Priority == TicketPriority.Unknown)
            return Result.Fail("Укажите приоритет задачи");
        
        if (request.Type == TicketType.Unknown)
            return Result.Fail("Укажите тип задачи");
        
        if (string.IsNullOrWhiteSpace(request.Name))
            return Result.Fail("Укажите название задачи");
        
        if (string.IsNullOrWhiteSpace(request.Description))
            return Result.Fail("Добавьте описание задачи");

        return Result.Ok();
    }
}

// public static class TestClass
// {
//     public static string ResultErrorString(Result obj)
//     {
//         return obj.Errors[0].ToString();
//     }
//     
//     public static string ResultTErrorString(Result<GetTicketsResponse> obj)
//     {
//         return obj.Errors[0].ToString();
//     }
// }