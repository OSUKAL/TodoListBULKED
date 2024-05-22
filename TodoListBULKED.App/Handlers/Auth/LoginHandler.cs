using System.Security.Claims;
using FluentResults;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.Auth;
using TodoLIstBULKED.Infrastructure.Cookie.Constants;
using TodoLIstBULKED.Infrastructure.Hashers;

namespace TodoListBULKED.App.Handlers.Auth;

/// <summary>
/// Обработчик авторизации пользователя
/// </summary>
public class LoginHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuthRepository _authRepository;
    private readonly ILogger<LoginHandler> _logger;
    private readonly IHasher _hasher;

    /// <inheritdoc cref="LoginHandler"/>
    public LoginHandler(IAuthRepository authRepository, ILogger<LoginHandler> logger, IHttpContextAccessor httpContextAccessor, IHasher hasher)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _hasher = hasher;
        _authRepository = authRepository;
    }

    /// <summary>
    /// Обработка авторизации пользователя
    /// </summary>
    /// <param name="request">Запрос на авторизацию</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Result> HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (_httpContextAccessor.HttpContext == null)
                return Result.Ok();

            var user = await _authRepository.GetByUsernameAsync(request.Username, cancellationToken);
            if (user == null)
                return Result.Fail("Пользователь с таким именем пользователя не найден");

            var isPasswordCorrect = _hasher.HashCompare(request.Password, user.PasswordHash);
            if (!isPasswordCorrect)
                return Result.Fail("Неверный пароль");

            var claims = new List<Claim>
            {
                new(CookieClaimConstants.UserId, user.Id.ToString()),
                new(CookieClaimConstants.UserRole, user.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            
            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string ErrorText = "При авторизации возникла ошибка";
            _logger.LogError(exception, ErrorText);

            return Result.Fail(ErrorText);
        }
    }
}