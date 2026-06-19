using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetaCRM.API.Models;

namespace MetaCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public OrganizationsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orgs = await _db.Organizations
                .Where(o => o.IsActive)
                .ToListAsync();
            return Ok(orgs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var org = await _db.Organizations.FindAsync(id);
            if (org == null) return NotFound();
            return Ok(org);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Organization org)
        {
            org.CreatedAt = DateTime.UtcNow;
            org.IsActive = true;
            _db.Organizations.Add(org);
            await _db.SaveChangesAsync();
            return Ok(org);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Organization updated)
        {
            var org = await _db.Organizations.FindAsync(id);
            if (org == null) return NotFound();

            org.Name = updated.Name;
            org.Phone = updated.Phone;
            org.Address = updated.Address;
            org.Email = updated.Email;
            org.Type = updated.Type;

            await _db.SaveChangesAsync();
            return Ok(org);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var org = await _db.Organizations.FindAsync(id);
            if (org == null) return NotFound();

            org.IsActive = false;
            await _db.SaveChangesAsync();
            return Ok(new { message = "O'chirildi" });
        }
    }
}