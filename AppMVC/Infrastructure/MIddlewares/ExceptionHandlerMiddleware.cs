namespace AppMVC.Infrastructure.MIddlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception)
        {
            await HandleExceptionMessageAsync(context).ConfigureAwait(false);
        }
    }

    private static Task HandleExceptionMessageAsync(HttpContext context)
    {
        context.Response.Redirect($"/error/500");
        return Task.CompletedTask;
    }
}