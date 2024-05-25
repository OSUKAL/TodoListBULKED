using TodoListBULKED.App.Models.User;

namespace TodoListBULKED.App.Abstractions;

/// <summary>
/// Репозиторий аутентификации
/// </summary>
public interface IAuthRepository
{
    /// <summary>
    /// Получение записи пользователя по имени пользователя
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task<UserModel?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}