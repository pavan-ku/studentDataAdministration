using Microsoft.AspNetCore.Mvc;
using StudentCore.Entities;
using StudentServices.Interfaces;

namespace Student.WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TeacherWebApi
    {
        private readonly ITeacherInterface _teacherInterface;
        public TeacherWebApi(ITeacherInterface teacherInterface)
        {
            _teacherInterface = teacherInterface;
        }
        [HttpPost("Create")]
        public async Task<TeacherEntities> CreateAsync(TeacherEntities teacher)
        {
            var result = await _teacherInterface.CreateTeacherById(teacher);
            return result;
        }
        [HttpPost("Get")]
        public async Task<TeacherEntities> GetAsync(int id)
        {
            var result = await _teacherInterface.GetAsync(id);
            return result;
        }
        [HttpPost("GetAll")]
        public async Task<IEnumerable<TeacherEntities>> GetAllStudents()
        {
            var result = await _teacherInterface.GetAllTeachers();
            return result;
        }
        [HttpPost("Update")]
        public async Task<TeacherEntities> UpdateAsync(TeacherEntities student)
        {
            var result = await _teacherInterface.UpdateAsync(student);
            return result;
        }
        [HttpPost("Delete")]
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _teacherInterface.DeleteAsync(id);
            return result;
        }
    }
}
