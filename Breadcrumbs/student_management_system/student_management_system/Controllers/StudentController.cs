using Microsoft.AspNetCore.Mvc;
using student_management_system.Models;
using student_management_system.Service;

namespace student_management_system.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/students/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDetail students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = await _studentService.AddStudentAsync(students);
            return CreatedAtAction(nameof(GetStudent), new { id = newStudent.StuId }, newStudent);
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudents(int id, [FromBody] StudentDetail updatedStudent)
        {
            if (id != updatedStudent.StuId)
            {
                return BadRequest();
            }

            var result = await _studentService.UpdateStudentAsync(updatedStudent);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "Student updated successfully" });
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "Student deleted successfully" });
        }
    }

}
