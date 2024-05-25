using FluentResults;

namespace TodoLIstBULKED.Infrastructure.Extensions;

/// <summary>
/// Класс расширения <see cref="Result"/>
/// </summary>
public static class ResultExtension
{
    /// <summary>
    /// Метод расширения для форматирования ошибок
    /// </summary>
    /// <param name="result"><see cref="ResultBase"/></param>
    public static string ErrorSummary(this IResultBase result)
    {
        return string.Join('\n', result.Errors);
    }
}