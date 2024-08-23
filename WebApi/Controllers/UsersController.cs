using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsersController : ControllerBase
{
    private static List<UserModel> _users =
        [
            new UserModel { FirstName = "Hans", LastName = "Mattin-Lassei", Email = "hans@domain.com" },
            new UserModel { FirstName = "Tommy", LastName = "Mattin-Lassei", Email = "tommy@domain.com" },
        ];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_users);
    }

    [HttpGet("{id}")]

    public IActionResult GetOne(string id)
    {  
        var user = _users.FirstOrDefault(x => x.Id == id);
        if (user != null)
        {
            return Ok(user);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult CreateOne(UserRequestModel model)
    {
        if (ModelState.IsValid)
        {
            var userModel = new UserModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };

            return Created("", userModel);
        }

        return BadRequest(model);
    }
}




