using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.API.Data;
using StudentEnrollment.API.Models.Domain;

namespace StudentEnrollment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;

        // B1 – GET: https://localhost:port/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _dbContext.Students.ToList();
            return Ok(students);
        }

        // B1 – GET: https://localhost:port/api/students/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // B2 – POST: https://localhost:port/api/students
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        // B3 – PUT: https://localhost:port/api/students/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateStudent([FromRoute] int id, [FromBody] Student updatedStudent)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            student.StudentName = updatedStudent.StudentName;
            student.Programme = updatedStudent.Programme;
            student.EnrollmentStatus = updatedStudent.EnrollmentStatus;

            _dbContext.SaveChanges();

            return Ok(student);
        }

        // B4 – DELETE: https://localhost:port/api/students/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteStudent([FromRoute] int id)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}