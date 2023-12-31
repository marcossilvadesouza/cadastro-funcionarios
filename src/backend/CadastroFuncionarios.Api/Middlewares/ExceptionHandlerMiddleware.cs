﻿using CadastroFuncionarios.Api.Infrastructure.Handlers;

namespace CadastroFuncionarios.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IExceptionHandler _handler;

    public ExceptionHandlerMiddleware(RequestDelegate next, IExceptionHandler handler)
    {
        _next = next;
        _handler = handler;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context).ConfigureAwait(continueOnCapturedContext: false);
        }
        catch (Exception exception)
        {
            await _handler.HandleAsync(context, exception).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
