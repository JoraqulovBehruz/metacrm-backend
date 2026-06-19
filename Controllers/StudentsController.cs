using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetaCRM.API.Models;

namespace MetaCRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StudentsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _db.Students
                .Where(s => s.IsActive)
                .Include(s => s.Organization)
                .Include(s => s.Group)
                .ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _db.Students
                .Include(s => s.Organization)
                .Include(s => s.Group)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            student.CreatedAt = DateTime.UtcNow;
            student.IsActive = true;
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student updated)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.FullName = updated.FullName;
            student.Phone = updated.Phone;
            student.ParentPhone = updated.ParentPhone;
            student.Address = updated.Address;
            student.BirthDate = updated.BirthDate;
            student.OrganizationId = updated.OrganizationId;
            student.GroupId = updated.GroupId;

            await _db.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();
            student.IsActive = false;
            await _db.SaveChangesAsync();
            return Ok(new { message = "O'chirildi" });
        }
    }
}