using Microsoft.AspNetCore.Diagnostics;

namespace AppMVC.Infrastructure.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        await Task.Run(() => Logger.Error($"Error! {exception.Message}"), cancellationToken);
        return true;
    }
}