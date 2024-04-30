using BusinessLayer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ClaimService claimService;

    public AuthController(ClaimService claimService)
    {
        this.claimService = claimService;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var claims = claimService.GetClaims(email, password);

        if (claims != null)
            await HttpContext.SignInAsync(claims);
        else
            return BadRequest();

        return Ok();
    }
}