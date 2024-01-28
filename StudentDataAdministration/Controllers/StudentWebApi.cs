using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentCore.Entities;
using StudentServices.Interfaces;

namespace Student.WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class StudentWebApi
    {
        private readonly IStudentInterface _studentInterface;
        public StudentWebApi(IStudentInterface studentInterface)
        {
            _studentInterface = studentInterface ;
        }
        [HttpPost("Create")]
        public async Task<StudentEntities> CreateAsync(StudentEntities student)
        {
            var result = await _studentInterface.CreateStudentById(student);
            return result;
        }
        [HttpPost("Get")]
        public async Task<StudentEntities> GetAsync(int id)
        {
            var result = await _studentInterface.GetAsync(id);
            return result;
        }
        [HttpPost("GetAll")]
        public async Task<IEnumerable<StudentEntities>> GetAllStudents()
        {
            var result = await _studentInterface.GetAllStudents();
            return result;
        }
        [HttpPost("Update")]
        public async Task<StudentEntities> UpdateAsync(StudentEntities student)
        {
            var result = await _studentInterface.UpdateAsync(student);
            return result;
        }
        [HttpPost("Delete")]
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _studentInterface.DeleteAsync(id);
            return result;
        }
    }
}
