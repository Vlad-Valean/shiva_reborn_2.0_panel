using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return await _userService.GetAsync(id);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            return await _userService.AddAsync(user);
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await _userService.RemoveAsync(id);
            return Ok(user);
        }

        [HttpPatch(Name = "UpdateAnUserInfo")]
        public async Task<ActionResult<User>> UpdateUser(string id, string firstName, string lastName, string email)
        {
            var users = await _userService.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Id == id);
            await _userService.RemoveAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            
            user.firstName = firstName;
            user.lastName = lastName;
            user.email = email;

            await _userService.AddAsync(user);

            return Ok(user);
        }
    }
}