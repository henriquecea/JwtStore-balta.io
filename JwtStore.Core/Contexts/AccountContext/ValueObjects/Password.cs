using JwtStore.Core.Contexts.SharedContext.ValueObjects;
using SecureIdentity.Password;

namespace JwtStore.Core.Contexts.AccountContext.ValueObjects;

public class Password : ValueObject
{
    private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    private const string Special = "!@#$%ˆ&*(){}[];Ç";

    protected Password()
    {

    }

    public Password(string? text = null)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            text = PasswordGenerator.Generate();

        Hash = PasswordHasher.Hash(text);
    }

    public string Hash { get; } = string.Empty;

    public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..8].ToUpper();

    public bool Challenge(string password) =>
        PasswordHasher.Verify(Hash, password);

}
