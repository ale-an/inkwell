using BusinessLayer.Models.Auth;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BusinessLayer.Infrastructure.Validators;

public class AuthValidator
{
    public void ValidateLogin(LoginForm form, ModelStateDictionary modelState)
    {
        ValidateEmail(form.Email, modelState);
        ValidatePassword(form.Password, modelState);
    }

    public void ValidateRegister(RegisterForm form, ModelStateDictionary modelState)
    {
        ValidateName(form.Name, modelState);
        ValidateEmail(form.Email, modelState);
        ValidatePassword(form.Password, modelState);
    }

    private void ValidateName(string? name, ModelStateDictionary modelState)
    {
        if (string.IsNullOrEmpty(name))
        {
            modelState.AddModelError("Name", "Имя не может быть пустым.");
        }
    }

    private void ValidateEmail(string email, ModelStateDictionary modelState)
    {
        if (string.IsNullOrEmpty(email))
        {
            modelState.AddModelError("Email", "Email не может быть пустым.");
            return;
        }

        if (!email.Contains('@') || email.Any(char.IsUpper))
        {
            modelState.AddModelError("Email", "Email должен содержать символ '@' и не содержать заглавных букв.");
        }
    }

    private void ValidatePassword(string password, ModelStateDictionary modelState)
    {
        if (string.IsNullOrEmpty(password))
        {
            modelState.AddModelError("Password", "Пароль не может быть пустым.");
        }
    }
}