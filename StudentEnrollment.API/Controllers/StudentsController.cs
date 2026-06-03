using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.API.Data;
using StudentEnrollment.API.Models.Domain;
using StudentEnrollment.API.Models.DTO;

namespace StudentEnrollment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;

        // B1 – GET
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _dbContext.Students.ToList();

            var studentsDTO = students.Select(s => new StudentDTO
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Programme = s.Programme,
                EnrollmentStatus = s.EnrollmentStatus
            }).ToList();

            return Ok(studentsDTO);
        }

        // B1 – GET
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Programme = student.Programme,
                EnrollmentStatus = student.EnrollmentStatus
            };

            return Ok(studentDTO);
        }

        // B2 – POST
        [HttpPost]
        public IActionResult CreateStudent([FromBody] AddStudentRequestDTO addStudentRequestDTO)
        {
            if (addStudentRequestDTO == null)
            {
                return BadRequest("Student data is null.");
            }

            var student = new Student
            {
                StudentName = addStudentRequestDTO.StudentName,
                Programme = addStudentRequestDTO.Programme,
                EnrollmentStatus = addStudentRequestDTO.EnrollmentStatus
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Programme = student.Programme,
                EnrollmentStatus = student.EnrollmentStatus
            };

            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, studentDTO);
        }

        // B3 – PUT:
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateStudent([FromRoute] int id, [FromBody] UpdateStudentRequestDTO updateStudentRequestDTO)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            student.StudentName = updateStudentRequestDTO.StudentName;
            student.Programme = updateStudentRequestDTO.Programme;
            student.EnrollmentStatus = updateStudentRequestDTO.EnrollmentStatus;

            _dbContext.SaveChanges();

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Programme = student.Programme,
                EnrollmentStatus = student.EnrollmentStatus
            };

            return Ok(studentDTO);
        }

        // B4 – DELETE
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

            return NoContent();
        }
    }
}