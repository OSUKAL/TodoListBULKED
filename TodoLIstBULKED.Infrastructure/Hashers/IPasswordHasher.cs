namespace TodoLIstBULKED.Infrastructure.Hashers;

/// <summary>
/// Хешер строк
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Хеширование строки
    /// </summary>
    /// <param name="input">Хешируемая строка</param>
    string Hash(string input);

    /// <summary>
    /// Сравнение хеша строки со строкой
    /// </summary>
    /// <param name="input">Строка для сравнения</param>
    /// <param name="hash">Хеш строки</param>
    bool HashCompare(string input, string hash);
}