﻿using MediatR;

namespace JwtStore.Api.Extension;

public static class AccountContextExtension
{
    public static void AddAccountContext(this WebApplicationBuilder builder)
    {
        #region Create

        builder.Services.AddTransient<
          Core.Contexts.AccountContext.UseCases.Create.Contract.IRepository,
          Infra.Contexts.AccountContext.UseCases.Create.Repository>();

        builder.Services.AddTransient<
            Core.Contexts.AccountContext.UseCases.Create.Contract.IService,
            Infra.Contexts.AccountContext.UseCases.Create.Service>();

        #endregion

        #region Authenticate

        builder.Services.AddTransient<
         Core.Contexts.AccountContext.UseCases.Authenticate.Contract.IRepository,
         Infra.Contexts.AccountContext.UseCases.Authenticate.Repository>();

        #endregion
    }

    public static void MapAccountEndpoints(this WebApplication app)
    {
        #region Create

        app.MapPost("api/v1/users", async (
            Core.Contexts.AccountContext.UseCases.Create.Request request,
            IRequestHandler<
                Core.Contexts.AccountContext.UseCases.Create.Request,
                Core.Contexts.AccountContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/users/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });

        #endregion

        #region Authenticate

        app.MapPost("api/v1/authenticate", async (
            Core.Contexts.AccountContext.UseCases.Authenticate.Request request,
            IRequestHandler<
                Core.Contexts.AccountContext.UseCases.Authenticate.Request,
                Core.Contexts.AccountContext.UseCases.Authenticate.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.Data is null)
                return Results.Json(result, statusCode: 500);

            result.Data.Token = JwtExtension.Generate(result.Data);
            return Results.Ok(result);
        });

        #endregion
    }
}
