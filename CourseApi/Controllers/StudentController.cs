using Microsoft.AspNetCore.Mvc;
using CourseApi.Data;
using CourseApi.Models;
using System.Linq;

namespace CourseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students
                                  .FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),
                                   new { id = student.Id },
                                   student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student updated)
        {
            var existing = _context.Students.Find(id);
            if (existing == null) return NotFound();

            existing.Name = updated.Name;
            existing.Email = updated.Email;
            existing.Phone = updated.Phone;
            existing.CourseId = updated.CourseId;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Students.Find(id);
            if (existing == null) return NotFound();

            _context.Students.Remove(existing);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
