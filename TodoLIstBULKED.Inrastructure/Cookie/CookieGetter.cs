using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace TodoLIstBULKED.Inrastructure.Cookie;

public class CookieGetter : ICookieGetter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieGetter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

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