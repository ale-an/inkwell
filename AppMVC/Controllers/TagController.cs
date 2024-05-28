using BusinessLayer.Models.Tag;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[Route("tags")]
public class TagController : Controller
{
    private readonly TagService tagService;

    public TagController(TagService tagService)
    {
        this.tagService = tagService;
    }

    [HttpPost("create")]
    public void Create([FromBody] TagModel model)
    {
        tagService.Create(model);
    }

    [HttpGet("list")]
    public TagModel[] List()
    {
        return tagService.GetAll();
    }

    [HttpGet("item/{id}")]
    public TagModel Item(int id)
    {
        return tagService.Get(id);
    }

    [HttpPut("update")]
    public void Update([FromBody] TagModel model)
    {
        tagService.Update(model);
    }

    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        tagService.Delete(id);
    }
}