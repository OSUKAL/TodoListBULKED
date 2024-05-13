namespace TodoLIstBULKED.Infrastructure.Hashers;

/// <summary>
/// Хешер строк
/// </summary>
public interface IHasher
{
    /// <summary>
    /// Хеширование строки
    /// </summary>
    /// <param name="input">Хешируемая строка</param>
    /// <returns></returns>
    string Hash(string input);

    /// <summary>
    /// Сравнение хеша строки со строкой
    /// </summary>
    /// <param name="input">Строка для сравнения</param>
    /// <param name="hash">Хеш строки</param>
    /// <returns></returns>
    bool HashCompare(string input, string hash);
}