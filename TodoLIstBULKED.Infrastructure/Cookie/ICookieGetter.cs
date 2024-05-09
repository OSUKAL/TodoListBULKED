using FluentResults;

namespace TodoLIstBULKED.Infrastructure.Cookie;

/// <summary>
/// Класс для работы с cookie
/// </summary>
public interface ICookieGetter
{
    /// <summary>
    /// Получение значения из cookie по ключу claim
    /// </summary>
    /// <param name="key">Ключ claim</param>
    Result<string> GetValueFromCookie(string key);
}