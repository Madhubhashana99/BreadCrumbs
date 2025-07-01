using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using student_management_system.Data;
using student_management_system.Models;

namespace student_management_system.Service
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        // Get All Students
        public async Task<IEnumerable<StudentDetail>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        // Get Student By ID
        public async Task<StudentDetail?> GetStudentByIdAsync(int id)
        {
           
            return await _context.Students.FindAsync(id);
        }

        // Add New Students
        public async Task<StudentDetail> AddStudentAsync(StudentDetail student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // Update Student
        public async Task<bool> UpdateStudentAsync(StudentDetail updatedStudent)
        {
            var existingStudent = await _context.Students.FindAsync(updatedStudent.StuId);
            if (existingStudent == null)
                return false;

            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.Email = updatedStudent.Email;
            existingStudent.PhoneNumber = updatedStudent.PhoneNumber;
            existingStudent.Gender = updatedStudent.Gender;
            existingStudent.Birthday = updatedStudent.Birthday;


            await _context.SaveChangesAsync();
            return true;
        }

        // Delete Student
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
