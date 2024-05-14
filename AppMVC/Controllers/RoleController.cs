using BusinessLayer.Models.Role;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[Route("roles")]
public class RoleController : Controller
{
    private readonly RoleService roleService;

    public RoleController(RoleService roleService)
    {
        this.roleService = roleService;
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        var roles = roleService.GetAll();

        var model = new RoleListModel(roles);

        return View(model);
    }

    [HttpGet("item/{id}")]
    public IActionResult Item(int id)
    {
        var model = roleService.Get(id);

        return View(model);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View("EditForm", new RoleForm());
    }

    [HttpPost("create")]
    public IActionResult Create(RoleForm form)
    {
        roleService.Create(form);
        return RedirectToAction("List");
    }

    [HttpGet("update")]
    public IActionResult Update(int id)
    {
        var model = roleService.GetForUpdate(id);
        return View("EditForm", model);
    }

    [HttpPost("update")]
    public IActionResult Update([FromForm] RoleForm itemModel)
    {
        roleService.Update(itemModel);
        return RedirectToAction("Item", new { itemModel.Id });
    }

    [HttpPost("delete/{id}")]
    public IActionResult Delete(int id)
    {
        roleService.Delete(id);
        return RedirectToAction("List");
    }
}