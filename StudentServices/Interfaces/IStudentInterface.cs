using StudentCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServices.Interfaces
{
    public interface IStudentInterface
    {
        Task<StudentEntities> GetAsync(int id);
        Task<StudentEntities> CreateStudentById(StudentEntities student);
        Task<StudentEntities> UpdateAsync(StudentEntities student);
        Task<bool> DeleteAsync(int Id);
        Task<IEnumerable<StudentEntities>> GetAllStudents();
    }
}
