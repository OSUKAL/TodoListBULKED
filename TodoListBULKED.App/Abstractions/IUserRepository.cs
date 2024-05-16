using TodoListBULKED.App.Models.User;

namespace TodoListBULKED.App.Abstractions;

/// <summary>
/// Репозиторий для работы с таблицей пользователей
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Создание записи пользователя
    /// </summary>
    /// <param name="userModel">Данные пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task InsertAsync(UserModel userModel, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение записи пользователя по имени пользователя
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task<UserModel?> GetByUsernameAsync(string username, CancellationToken cancellationToken);

    /// <summary>
    /// Получение записи пользователя по идентификатору
    /// </summary>
    /// <param name="userId">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    Task<UserModel?> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
}