namespace CadastroFuncionarios.Api.Infrastructure.Handlers;

public interface IExceptionHandler
{
    Task HandleAsync(HttpContext context, Exception exception);
}
