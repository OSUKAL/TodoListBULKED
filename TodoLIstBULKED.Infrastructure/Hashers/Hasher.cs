using System.Security.Cryptography;

namespace TodoLIstBULKED.Infrastructure.Hashers;

/// <inheritdoc/>
public class Hasher : IHasher           
{
    private const int SaltLength = 16;
    private const int HashLength = 16;
    private const int Iterations = 1337;
    private const char Separator = '-';
    
    private readonly HashAlgorithmName AlgorithmName = HashAlgorithmName.SHA512;
    
    /// <inheritdoc/>
    public string Hash(string input)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltLength);
        var hash = Rfc2898DeriveBytes.Pbkdf2(input, salt, Iterations, AlgorithmName, HashLength);

        return string.Join(Separator, Convert.ToHexString(hash), Convert.ToHexString(salt), Iterations, AlgorithmName);
    }

    /// <inheritdoc/>
    public bool HashCompare(string input, string hashedString)
    {
        var segments = hashedString.Split(Separator);
        var hash = Convert.FromHexString(segments[0]);
        var salt = Convert.FromHexString(segments[1]);
        var iterations = int.Parse(segments[2]);
        var algorithm = new HashAlgorithmName(segments[3]);
        var hashedInput = Rfc2898DeriveBytes.Pbkdf2(input, salt, iterations, algorithm, hash.Length);
        
        return CryptographicOperations.FixedTimeEquals(hashedInput, hash);
    }
}