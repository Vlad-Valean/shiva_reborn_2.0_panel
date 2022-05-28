using Microsoft.AspNetCore.Mvc;
using ShivaReborn.Business.Interfaces;
using ShivaReborn.DataAccess.Models;
using ShivaReborn.DataAccess.Repositories;

namespace ShivaReborn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService<User> _userService;

        public UsersController(IService<User> userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("GetOneUser")]
        public async Task<ActionResult<User>> GetOneUser(string id)
        {
            var users = await _userService.GetAllAsync();
            var user = users.FirstOrDefault(u => u.id == id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var users = await _userService.GetAllAsync();
            var user = users.FirstOrDefault(u => u.id == id);

            if (user is null)
            {
                return NotFound();
            }

            var usersList = users.ToList();
            usersList.Remove(user);
            users = usersList.AsEnumerable();
            return Ok(user);
        }

        [HttpPatch(Name = "UpdateAnUserInfo")]
        public async Task<ActionResult<User>> UpdateUser(string id, string firstName, string lastName, string email)
        {
            var users = await _userService.GetAllAsync();
            var user = users.FirstOrDefault(u => u.id == id);

            if (user is null)
            {
                return NotFound();
            }

            user.firstName = firstName;
            user.lastName = lastName;
            user.email = email;
            return Ok(user);
        }
    }
}