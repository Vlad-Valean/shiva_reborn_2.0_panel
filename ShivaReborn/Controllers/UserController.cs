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
        public async Task<ActionResult<User>> GetOneUser(int id)
        {
            return await _userService.GetAsync(id);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            return await _userService.AddAsync(user);
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userService.RemoveAsync(id);
            return Ok(user);
        }

        [HttpPatch(Name = "UpdateAnUserInfo")]
        public async Task<ActionResult<User>> UpdateUser(int id, string firstName, string lastName, string email)
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

            await _userService.AddAsync(user);

            return Ok(user);
        }
        [HttpPut(Name = "Register")]
        public async Task<ActionResult<User>> Register([FromBody]User _user)
        {
            var users = await _userService.GetAllAsync();
            var user = users.FirstOrDefault(u => u.email == _user.email);
            if (user is null)
            {
                _userService.AddAsync(user);
                return Ok(user);
            }
            throw new Exception($"Email already exists");
        }
        [HttpGet(Name = "Login")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            var users = await _userService.GetAllAsync();
            var _user = users.FirstOrDefault(u => u.email == email);
            if (_user is null)
            {
                throw new Exception($"Couldn't find in the database the user with email : {email}");
            }

            if (_user.password != password)
            {
                throw new Exception($"Wrong Password");
            }

            return Ok(_user);
        }
    }
}