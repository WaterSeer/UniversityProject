using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;

namespace UniversityProject.Infrastucture.Data
{
    public class EFCourseRepository : IRepository<Course>
    {
        private UniversityContext _context;
        public EFCourseRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Course> GetAll() => _context.Courses;

        public Course Get(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.CourseId == id);
        } 
        public async Task<Course> DeleteAsync(int courseId)
        {
            Task<Course> dbEntry = _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
            if (dbEntry != null)
            {
                _context.Courses.Remove(dbEntry.Result);
                await _context.SaveChangesAsync();
            }
            return await dbEntry;
        }        

        public async Task<Course> UpdateAsync(Course course)
        {
            Course dbEntry = new Course();
            if (course.CourseId == 0)
            {
                await _context.Courses.AddAsync(course);
            }
            else
            {
                dbEntry = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == course.CourseId);
                if (dbEntry != null)
                {
                    dbEntry.Name = course.Name;
                    dbEntry.Description = course.Description;
                }
            }
            await _context.SaveChangesAsync();
            return dbEntry;
        }
    }
}
