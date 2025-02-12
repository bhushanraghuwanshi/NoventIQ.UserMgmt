using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoventIQ.UserMgmt;
using NoventIQ.UserMgmt.Models;

namespace NoventIQ.UserMgmt.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly AppDbContext _context;

        public RoleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRoles), new { id = role.Id }, role);
        }
    }
}
