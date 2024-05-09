using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace TodoLIstBULKED.Infrastructure.Cookie;

/// <inheritdoc/>
public class CookieGetter : ICookieGetter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <inheritdoc cref="CookieGetter"/>
    public CookieGetter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc/>
    public Result<string> GetValueFromCookie(string key)
    {
        var claims = _httpContextAccessor.HttpContext?.User.Claims.DefaultIfEmpty().ToArray();
        if (claims.IsNullOrEmpty())
            return Result.Fail("Не удалось получить данные из cookie");

        var claimsDictionary = claims.ToDictionary(c => c.Type, c => c.Value);
        if (!claimsDictionary.TryGetValue(key, out var userValueString))
            return Result.Fail("Не удалось получить данные из cookie");

        return Result.Ok(userValueString);
    }
}