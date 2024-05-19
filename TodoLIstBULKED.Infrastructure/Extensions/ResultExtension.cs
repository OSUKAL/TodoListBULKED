using FluentResults;

namespace TodoLIstBULKED.Infrastructure.Extensions;

public static class ResultExtension
{
    public static string ErrorSummary(this IResultBase result)
    {
        return string.Join('\n', result.Errors);
    }
}