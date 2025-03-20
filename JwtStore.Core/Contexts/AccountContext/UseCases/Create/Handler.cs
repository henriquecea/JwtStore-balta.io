using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.AccountContext.Entities;
using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contract;
using JwtStore.Core.Contexts.AccountContext.ValueObjects;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create;

public class Handler
{
    private readonly IRepository _repository;
    private readonly IService _service;

    public Handler(IRepository repository, IService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        try
        {
            var res = Specification.Ensure(request);

            if (!res.IsValid)
                return new Response("Requisição inválida.", 400, res.Notifications);
        }
        catch
        {
            return new Response("Não foi possível validar sua req", 500, null);
        }

        Email email;
        Password password;
        User user;

        try
        {
            email = new Email(request.Email);
            password = new Password(request.Password);
            user = new User(request.Name, email, password);

        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400, null);
        }

        try
        {
            var exists = await _repository.AnyAsync(request.Email, cancellationToken);

            if (exists)
                return new Response("E-mail já cadastrado.", 400, null);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 500, null);
        }
    }
}