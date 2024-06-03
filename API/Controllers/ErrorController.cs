using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("error")]
public class ErrorController : Controller
{
    [HttpGet("{statusCode}")]
    public IActionResult ErrorPage(string statusCode)
    {
        switch (statusCode)
        {
            case "404":
                return View("NotFoundView");
            case "403":
                return View("ForbiddenView");
            default:
                return View("ServerErrorView");
        }
    }
}