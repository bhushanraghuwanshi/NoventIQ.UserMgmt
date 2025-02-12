using Microsoft.AspNetCore.Mvc;
using NoventIQ.UserMgmt.Models;
using NoventIQ.UserMgmt.Repositories;
using Microsoft.EntityFrameworkCore;


namespace NoventIQ.UserMgmt.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _Context;

        
        public UserController(AppDbContext context)
        {
            _Context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _Context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            _Context.Users.Add(user);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}

