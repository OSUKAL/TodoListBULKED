using FluentResults;

namespace TodoLIstBULKED.Inrastructure.Cookie;

public interface ICookieGetter
{
    Result<string> GetValueFromCookie(string key);
}