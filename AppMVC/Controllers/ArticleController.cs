using BusinessLayer.Models;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[Route("articles")]
public class ArticleController : ControllerBase
{
    private readonly ArticleService articleService;

    public ArticleController(ArticleService articleService)
    {
        this.articleService = articleService;
    }

    [HttpPost("create")]
    public void Create([FromBody] ArticleModel model)
    {
        articleService.Create(model);
    }

    [HttpGet("list")]
    public ArticleModel[] List()
    {
        return articleService.GetAll();
    }

    [HttpGet("item/{id}")]
    public ArticleModel Item(int id)
    {
        return articleService.Get(id);
    }

    [HttpPut("update")]
    public void Update([FromBody] ArticleModel model)
    {
        articleService.Update(model);
    }

    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        articleService.Delete(id);
    }
}