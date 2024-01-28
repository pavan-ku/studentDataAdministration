using StudentCore.Entities;

namespace StudentServices.Interfaces
{
    public interface ITeacherInterface
    {
        Task<TeacherEntities> GetAsync(int id);
        Task<TeacherEntities> CreateTeacherById(TeacherEntities teacher);
        Task<TeacherEntities> UpdateAsync(TeacherEntities teacher);
        Task<bool> DeleteAsync(int Id);
        Task<IEnumerable<TeacherEntities>> GetAllTeachers();
    }
}
