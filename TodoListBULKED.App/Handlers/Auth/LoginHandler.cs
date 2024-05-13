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
    private readonly IUserRepository _userRepository;
    private readonly ILogger<LoginHandler> _logger;
    private readonly IHasher _hasher;

    /// <inheritdoc cref="LoginHandler"/>
    public LoginHandler(IUserRepository userRepository, ILogger<LoginHandler> logger, IHttpContextAccessor httpContextAccessor, IHasher hasher)
    {
        _userRepository = userRepository;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _hasher = hasher;
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
            var validationResult = ValidateRequest(request);
            if (validationResult.IsFailed)
                return validationResult;

            if (_httpContextAccessor.HttpContext == null)
                return Result.Ok();

            var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
            if (user == null)
                return Result.Fail("Пользователь с таким именем пользователя не найден");

            var isPasswordCorrect = _hasher.HashCompare(request.Password, user.PasswordHash);
            if (!isPasswordCorrect)
                return Result.Fail("Неверный пароль");

            var claims = new List<Claim>
            {
                new(CookieClaimConstants.UserId, user.Id.ToString())
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

    private static Result ValidateRequest(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Указано неверное имя пользователя");

        if (string.IsNullOrWhiteSpace(request.Password))
            return Result.Fail("Указан неверный пароль");

        return Result.Ok();
    }
}