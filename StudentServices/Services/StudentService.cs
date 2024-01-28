using Microsoft.EntityFrameworkCore;
using StudentCore.AppDbContext;
using StudentCore.Entities;
using StudentDTO.StudentDto;
using StudentServices.Interfaces;
using System.Reflection.Metadata;

namespace StudentServices.Services
{
    public class StudentService : IStudentInterface
    {
        public  DataContext _dataContext;
        private DbContext DbContext;
        private String DoesNotExist = "Student does not exist";
        private String AlreadyExist = "Student already exist";
        public StudentService (DataContext dataContext)
        {
            _dataContext = dataContext;
            DbContext = dataContext;
        }
        public async Task<StudentEntities> CreateStudentById(StudentEntities student)
        {
            var message = string.Empty;
            var existingStudent = await _dataContext.Students.FindAsync(student.Id);
            if(existingStudent == null)
            {
                _dataContext.Students.Add(student);
                await DbContext.SaveChangesAsync();
                //return student;
            }
            else
            {
                message = AlreadyExist;
            }
            return student;
            
        }
        public async Task<StudentEntities> GetAsync(int Id)
        {
            return await _dataContext.Students.FindAsync(Id);
        }
        public async Task<IEnumerable<StudentEntities>> GetAllStudents()
        {
            return await _dataContext.Students.ToListAsync();
        }
        public async Task<StudentEntities> UpdateAsync(StudentEntities student)
        {
            var message = string.Empty;
            var existingStudent = await _dataContext.Students.FindAsync(student.Id);
            if (existingStudent != null)
            {
                student.Id = existingStudent.Id;
                student.FirstName = existingStudent.FirstName;
                student.LastName = existingStudent.LastName;
                student.Email = existingStudent.Email;
                student.DatOfBirth = existingStudent.DatOfBirth;
            }
            else
            {
                message = DoesNotExist;
            }
            await DbContext.SaveChangesAsync();
            return existingStudent;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var student = await _dataContext.Students.FindAsync(Id);
            if (student == null)
            {
                return false;
                
            }
            else
            {
                _dataContext.Students.Remove(student);
                await DbContext.SaveChangesAsync();
                return true;
            }
        }
    }   
}
