using FluentResults;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TodoListBULKED.App.Handlers.Auth;

/// <summary>
/// Обработчик выхода из аккаунта
/// </summary>
public class LogoutHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<LogoutHandler> _logger;

    /// <inheritdoc cref="LogoutHandler"/>
    public LogoutHandler(IHttpContextAccessor httpContextAccessor, ILogger<LogoutHandler> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    /// <summary>
    /// Обработка выхода из аккаунта
    /// </summary>
    public async Task<Result> HandleAsync()
    {
        try
        {
            if (_httpContextAccessor.HttpContext == null)
                return Result.Ok();
        
            await _httpContextAccessor.HttpContext.SignOutAsync();
        
            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string ErrorText = "При выходе из аккаунта возникла ошибка";
            _logger.LogError(exception, ErrorText);
            
            return Result.Fail(ErrorText);
        }
    }
}