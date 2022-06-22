using Microsoft.AspNetCore.Mvc;
using Users.Core;

namespace Users.WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUSerServices _userservices;
        public UserController(IUSerServices Userservices)
        {
            _userservices = Userservices;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userservices.GetUsers());
        }

        [HttpGet( "{Id}", Name = "GetUser")]
        public IActionResult GetUser(string id)
    {
        return Ok(_userservices.GetUser(id));
    }


    [HttpPost]
    public IActionResult AddUser(User user)
    {
        _userservices.AddUser(user);
        return CreatedAtRoute("GetUser", new { id = user.id }, user);
    }

    [HttpDelete("{id}")]
     
    public IActionResult DeleteUser(string id)
        {
            _userservices.DeleteUser(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            return Ok(_userservices.UpdateUser(user));
        }

    }
}

