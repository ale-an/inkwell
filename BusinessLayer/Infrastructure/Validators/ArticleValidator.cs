using BusinessLayer.Models.Article;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BusinessLayer.Infrastructure.Validators;

public class ArticleValidator
{
    public void Validate(ArticleForm form, ModelStateDictionary modelState)
    {
        ValidateTitle(form, modelState);
        ValidateContent(form, modelState);
    }

    private void ValidateTitle(ArticleForm form, ModelStateDictionary modelState)
    {
        if (string.IsNullOrEmpty(form.Title))
        {
            modelState.AddModelError(nameof(form.Title), "Заголовок не может быть пустым.");
            return;
        }

        if (form.Title.Length > 30)
            modelState.AddModelError(nameof(form.Title), "Длина заголовка не может превышать 30 символов.");
    }

    private void ValidateContent(ArticleForm form, ModelStateDictionary modelState)
    {
        if (string.IsNullOrEmpty(form.Content))
        {
            modelState.AddModelError(nameof(form.Content), "Статья не может быть пустой. Попробуйте фрирайтинг.");
        }
    }
}