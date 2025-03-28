using Flunt.Notifications;
using JwtStore.Core.Contexts.SharedContext.UseCases;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Authenticate;

public class Response : ResponseBase
{
    protected Response()
    {
    }

    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {

    }

    public Response(string message, ResponseData data)
    {
        Message = message;
        Status = 201;
        Notifications = null;
        Data = data;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData()
{
    public string Token { get; set; } = string.Empty;

    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string[] Roles { get; set; } = [];
}
