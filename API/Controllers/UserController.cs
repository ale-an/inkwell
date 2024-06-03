using BusinessLayer.Models.User;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("users")]
public class UserController : Controller
{
    private readonly UserService userService;

    public UserController(UserService userService)
    {
        this.userService = userService;
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        var users = userService.GetAll();

        var model = new UserListModel(users);

        return View(model);
    }

    [HttpGet("item/{id}")]
    public IActionResult Item(int id)
    {
        var model = userService.Get(id);

        return View(model);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View("EditForm", new UserForm());
    }

    [HttpPost("create")]
    public IActionResult Create(UserForm form)
    {
        userService.Create(form);
        return RedirectToAction("List");
    }

    [HttpGet("update")]
    public IActionResult Update(int id)
    {
        var model = userService.GetForUpdate(id);
        return View("EditForm", model);
    }

    [HttpPost("update")]
    public IActionResult Update([FromForm] UserForm itemModel)
    {
        userService.Update(itemModel);
        return RedirectToAction("Item", new { itemModel.Id });
    }

    [HttpPost("delete/{id}")]
    public IActionResult Delete(int id)
    {
        userService.Delete(id);
        return RedirectToAction("List");
    }
}