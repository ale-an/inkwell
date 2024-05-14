using BusinessLayer.Models.Auth;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[Route("auth")]
public class AuthController : Controller
{
    private readonly ClaimService claimService;
    private readonly UserService userService;

    public AuthController(ClaimService claimService, UserService userService)
    {
        this.claimService = claimService;
        this.userService = userService;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View(new LoginForm());
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginForm form)
    {
        var claims = claimService.GetClaims(form.Email, form.Password);

        if (claims != null)
            await HttpContext.SignInAsync(claims);
        else
            return BadRequest();

        return RedirectToAction("List", "Article");
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("List", "Article");
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View(new RegisterForm());
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterForm form)
    {
        userService.Create(form);
        return RedirectToAction("Login");
    }
}