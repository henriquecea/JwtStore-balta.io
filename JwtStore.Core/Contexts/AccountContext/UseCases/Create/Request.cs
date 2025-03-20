namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create;

public class Request
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
