using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contract;

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

    //public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        var res = Specification.Ensure(request);

    //        if (!res.IsValid)
    //            return new Response("Requisição inválida.", 400, res.Notifications);
    //    }
    //    catch
    //    {
    //        return new Response("Não foi possível validar sua req", 500, null);
    //    }


    }
}