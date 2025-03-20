namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contract;

public interface IRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
}
