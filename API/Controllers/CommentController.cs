using BusinessLayer.Models.Comment;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("comments")]
public class CommentController : Controller
{
    private readonly CommentService commentService;

    public CommentController(CommentService commentService)
    {
        this.commentService = commentService;
    }

    [HttpPost("create")]
    public IActionResult Create(CommentForm form)
    {
        commentService.Create(form);
        return RedirectToAction("Item", "Article", new { id = form.ArticleId });
    }

    [HttpPost("update")]
    public IActionResult Update(CommentForm form)
    {
        commentService.Update(form);
        return RedirectToAction("Item", "Article", new { id = form.ArticleId });
    }

    [HttpPost("delete/{articleId}/{id}")]
    public IActionResult Delete(int articleId, int id)
    {
        commentService.Delete(id);
        return RedirectToAction("Item", "Article", new { id = articleId });
    }
}