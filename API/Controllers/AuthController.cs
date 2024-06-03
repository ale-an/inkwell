using BusinessLayer.Infrastructure.Validators;
using BusinessLayer.Models.Auth;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("auth")]
public class AuthController : Controller
{
    private readonly ClaimService claimService;
    private readonly UserService userService;
    private readonly AuthValidator authValidator;

    public AuthController(ClaimService claimService, UserService userService, AuthValidator authValidator)
    {
        this.claimService = claimService;
        this.userService = userService;
        this.authValidator = authValidator;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View(new LoginForm());
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginForm form)
    {
        authValidator.ValidateLogin(form, ModelState);

        if (!ModelState.IsValid)
        {
            return View(form);
        }

        var claims = claimService.GetClaims(form.Email, form.Password);

        if (claims != null)
        {
            await HttpContext.SignInAsync(claims);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Неправильный email или пароль.");
            return View(form);
        }

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
        authValidator.ValidateRegister(form, ModelState);

        if (!ModelState.IsValid)
        {
            return View(form);
        }

        userService.Create(form);
        return RedirectToAction("Login");
    }
}