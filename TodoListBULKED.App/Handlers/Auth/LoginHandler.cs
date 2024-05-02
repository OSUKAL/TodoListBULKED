using System.Security.Claims;
using FluentResults;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TodoListBULKED.App.Abstractions;
using TodoListBULKED.App.Models.Requests.Auth;

namespace TodoListBULKED.App.Handlers.Auth;

/// <summary>
/// Обработчик авторизации пользователя
/// </summary>
public class LoginHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<LoginHandler> _logger;

    /// <inheritdoc cref="LoginHandler"/>
    public LoginHandler(IUserRepository userRepository, ILogger<LoginHandler> logger, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
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

            var passwordChecked = PasswordCheck(request.Password, user.Password);
            if (!passwordChecked)
                return Result.Fail("Неверный пароль");

            var claims = new List<Claim>
            {
                new("UserId", user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            
            return Result.Ok();
        }
        catch (Exception exception)
        {
            const string errorText = "При авторизации возникла ошибка";
            _logger.LogError(exception, errorText);

            return Result.Fail(errorText);
        }
    }

    private Result ValidateRequest(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
            return Result.Fail("Указано неверное имя пользователя");

        if (string.IsNullOrWhiteSpace(request.Password))
            return Result.Fail("Указан неверный пароль");

        return Result.Ok();
    }

    private bool PasswordCheck(string loginPassword, string userPassword)
    {
        return loginPassword.Equals(userPassword);
    }
}