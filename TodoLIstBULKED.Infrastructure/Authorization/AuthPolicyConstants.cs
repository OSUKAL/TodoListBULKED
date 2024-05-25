namespace TodoLIstBULKED.Infrastructure.Authorization;

/// <summary>
/// Константы политик авторизации
/// </summary>
public static class AuthPolicyConstants
{
    /// <summary>
    /// Только пользователи с ролью администратора
    /// </summary>
    public const string AdminOnly = "AdminOnly";

    /// <summary>
    /// Только авторизированные пользователи
    /// </summary>
    public const string Default = "Default";
}