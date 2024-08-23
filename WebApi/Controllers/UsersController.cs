using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<UserModel> _users = new List<UserModel>
        {
            new UserModel { FirstName = "William", LastName = "Björklund", Email = "wb@gmail.com" },
            new UserModel { FirstName = "Anton", LastName = "Håkansson", Email = "Håkansson@gmail.com" },
        };

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

                _users.Add(userModel);

                return Created("", userModel);
            }

            return BadRequest(ModelState);
        }
    }
}

