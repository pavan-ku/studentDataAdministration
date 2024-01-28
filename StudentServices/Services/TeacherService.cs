using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentCore.AppDbContext;
using StudentCore.Entities;
using StudentServices.Interfaces;

namespace StudentServices.Services
{
    public class TeacherService : ITeacherInterface
    {
        public DataContext _dataContext;
        public DbContext DbContext;
        private String DoesNotExist = "Teacher does not exist";
        public TeacherService(DataContext dataContext)
        {
            _dataContext = dataContext;
            DbContext = dataContext;
        }
        public async Task<TeacherEntities> CreateTeacherById(TeacherEntities teacher)
        {
            _dataContext.Teachers.Add(teacher);
            await DbContext.SaveChangesAsync();
            return teacher;
        }
        public async Task<TeacherEntities> GetAsync(int Id)
        {
            return await _dataContext.Teachers.FindAsync(Id);
        }
        public async Task<IEnumerable<TeacherEntities>> GetAllTeachers()
        {
            return await _dataContext.Teachers.ToListAsync();
        }
        public async Task<TeacherEntities> UpdateAsync(TeacherEntities teacher)
        {
            var message = string.Empty;
            var existingTeacher = await _dataContext.Teachers.FindAsync(teacher.T_id);
            if (existingTeacher != null)
            {
                teacher.T_id = existingTeacher.T_id;
                teacher.teacherName = existingTeacher.teacherName;
                teacher.teacherLastName = existingTeacher.teacherLastName;
                teacher.teacherEmail = existingTeacher.teacherEmail;
            }
            else
            {
                message = DoesNotExist;
            }
            await DbContext.SaveChangesAsync();
            return existingTeacher;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var teacher = await _dataContext.Teachers.FindAsync(Id);
            if (teacher == null)
            {
                return false;

            }
            else
            {
                _dataContext.Teachers.Remove(teacher);
                await DbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
