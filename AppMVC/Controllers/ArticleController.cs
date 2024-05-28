using AppMVC.Infrastructure.Filters;
using BusinessLayer.Infrastructure.Validators;
using BusinessLayer.Models.Article;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[LogActionFilter]
[Route("articles")]
public class ArticleController : Controller
{
    private readonly ArticleService articleService;
    private readonly ArticleValidator articleValidator;

    public ArticleController(ArticleService articleService, ArticleValidator articleValidator)
    {
        this.articleService = articleService;
        this.articleValidator = articleValidator;
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        var articles = articleService.GetAll();

        var model = new ArticleListModel(articles);

        return View(model);
    }

    [HttpGet("item/{id}")]
    public IActionResult Item(int id)
    {
        var model = articleService.Get(id);

        return View(model);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View("EditForm", new ArticleForm());
    }

    [HttpPost("create")]
    public IActionResult Create(ArticleForm form)
    {
        articleValidator.Validate(form, ModelState);

        if (!ModelState.IsValid)
            return View("EditForm", form);

        articleService.Create(form);
        return RedirectToAction("List");
    }

    [HttpGet("update")]
    public IActionResult Update(int id)
    {
        var model = articleService.GetForUpdate(id);
        return View("EditForm", model);
    }

    [HttpPost("update")]
    public IActionResult Update([FromForm] ArticleForm form)
    {
        articleValidator.Validate(form, ModelState);

        if (!ModelState.IsValid)
            return View("EditForm", form);

        articleService.Update(form);
        return RedirectToAction("Item", new { form.Id });
    }

    [HttpPost("delete/{id}")]
    public IActionResult Delete(int id)
    {
        articleService.Delete(id);
        return RedirectToAction("List");
    }
}