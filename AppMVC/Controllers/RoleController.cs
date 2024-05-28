using AppMVC.Infrastructure.Filters;
using BusinessLayer.Infrastructure.Validators;
using BusinessLayer.Models.Role;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[LogActionFilter]
[Route("roles")]
public class RoleController : Controller
{
    private readonly RoleService roleService;
    private readonly RoleValidator roleValidator;

    public RoleController(RoleService roleService, RoleValidator roleValidator)
    {
        this.roleService = roleService;
        this.roleValidator = roleValidator;
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
        roleValidator.Validate(form, ModelState);

        if (!ModelState.IsValid)
            return View("EditForm", form);

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
    public IActionResult Update([FromForm] RoleForm form)
    {
        roleValidator.Validate(form, ModelState);

        if (!ModelState.IsValid)
            return View("EditForm", form);

        roleService.Update(form);
        return RedirectToAction("Item", new { form.Id });
    }

    [HttpPost("delete/{id}")]
    public IActionResult Delete(int id)
    {
        roleService.Delete(id);
        return RedirectToAction("List");
    }
}