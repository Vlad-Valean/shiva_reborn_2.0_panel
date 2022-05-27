using Microsoft.AspNetCore.Mvc;
using ShivaReborn.DataAccess.Models;
namespace ShivaReborn.Controllers;

public class UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = NULL;
            return Ok(users);
        }

    }
}