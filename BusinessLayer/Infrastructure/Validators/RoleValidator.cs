using BusinessLayer.Models.Role;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BusinessLayer.Infrastructure.Validators;

public class RoleValidator
{
    public void Validate(RoleForm form, ModelStateDictionary modelState)
    {
        if (string.IsNullOrEmpty(form.Name))
        {
            modelState.AddModelError(nameof(form.Name), "Имя не может быть пустым.");
            return;
        }

        if (form.Name.Length > 10)
            modelState.AddModelError(nameof(form.Name), "Длина имени не может превышать 10 символов.");
    }
}