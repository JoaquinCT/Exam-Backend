using Microsoft.AspNetCore.Mvc;
using CourseApi.Data;
using CourseApi.Models;
using System.Linq;

namespace CourseApi.Controllers
{
    [ApiController]                                    
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _context.Courses.ToList();
            return Ok(courses);                       
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _context.Courses
                                 .FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();    
            return Ok(course);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById),
                                   new { id = course.Id },
                                   course);      
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course updated)
        {
            var existing = _context.Courses.Find(id);
            if (existing == null) return NotFound();

            existing.Name = updated.Name;
            existing.Description = updated.Description;
            existing.ImageUrl = updated.ImageUrl;
            existing.Schedule = updated.Schedule;
            existing.Professor = updated.Professor;
            _context.SaveChanges();

            return NoContent();                       
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Courses.Find(id);
            if (existing == null) return NotFound();

            _context.Courses.Remove(existing);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
