using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Infrastructure.Filters;

public class LogActionFilter : ActionFilterAttribute
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;
        var reader = new StreamReader(request.Body);
        Logger.Info($"New request - {DateTime.Now: dd.MM.yyyy HH:mm:ss}");
        Logger.Info($"Request method: {request.Method}");
        Logger.Info(
            $"Request Username {context.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value}");
        base.OnActionExecuting(context);
    }
}