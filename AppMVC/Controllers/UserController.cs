using BusinessLayer.Models;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers;

[Route("users")]
public class UserController : ControllerBase
{
    private readonly UserService userService;

    public UserController(UserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("create")]
    public void Create([FromBody] UserModel model)
    {
        userService.Create(model);
    }

    [HttpGet("list")]
    public UserModel[] List()
    {
        return userService.GetAll();
    }

    [HttpGet("item/{id}")]
    public UserModel Item(int id)
    {
        return userService.Get(id);
    }

    [HttpPut("update")]
    public void Update([FromBody] UserModel model)
    {
        userService.Update(model);
    }

    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        userService.Delete(id);
    }
}