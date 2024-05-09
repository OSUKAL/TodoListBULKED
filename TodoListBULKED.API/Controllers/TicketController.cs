﻿using Microsoft.AspNetCore.Mvc;
using TodoListBULKED.App.Handlers.Ticket;
using TodoListBULKED.App.Models.Requests.Ticket;
using TodoLIstBULKED.Infrastructure.Cookie;
using TodoLIstBULKED.Infrastructure.Cookie.Constants;

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
    
    /// <inheritdoc cref="TicketController"/>
    public TicketController(CreateTicketHandler createTicketHandler, ICookieGetter cookieGetter)
    {
        _createTicketHandler = createTicketHandler;
        _cookieGetter = cookieGetter;
    }

    /// <summary>
    /// Создание задачи
    /// </summary>
    /// <param name="request">Запрос на создание задачи</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var userIdResult = _cookieGetter.GetValueFromCookie(CookieClaims.UserId);

        Console.WriteLine(userIdResult);
        
        var userId = Guid.Parse(userIdResult.Value);

        var result = await _createTicketHandler.HandleAsync(request, userId, cancellationToken);
        if (result.IsFailed)
            return BadRequest(result.Errors[0].ToString());

        return Ok();
    }
}