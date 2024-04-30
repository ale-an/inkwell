using BusinessLayer.Models;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[Route("comments")]
public class CommentController : ControllerBase
{
    private readonly CommentService commentService;

    public CommentController(CommentService commentService)
    {
        this.commentService = commentService;
    }

    [HttpPost("create")]
    public void Create([FromBody] CommentModel model)
    {
        commentService.Create(model);
    }

    [HttpGet("list")]
    public CommentModel[] List()
    {
        return commentService.GetAll();
    }

    [HttpGet("item/{id}")]
    public CommentModel Item(int id)
    {
        return commentService.Get(id);
    }

    [HttpPut("update")]
    public void Update([FromBody] CommentModel model)
    {
        commentService.Update(model);
    }

    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        commentService.Delete(id);
    }
}