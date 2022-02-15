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
        public async Task<Course> GetAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
        }


        public Course Delete(int courseId)
        {
            Course dbEntry = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (dbEntry != null)
            {
                _context.Courses.Remove(dbEntry);
                _context.SaveChangesAsync();
            }
            return dbEntry;
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

        public void Update(Course course)
        {
            if (course.CourseId == 0)
            {
                _context.Courses.Add(course);
            }
            else
            {
                Course dbEntry = _context.Courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                if (dbEntry != null)
                {
                    dbEntry.Name = course.Name;
                    dbEntry.Description = course.Description;
                }
            }
            _context.SaveChanges();
        }
    }
}
