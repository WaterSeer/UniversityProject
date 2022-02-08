using System;
using System.Linq;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;

namespace UniversityProject.Infrastucture.Data
{
    public class EFCourseRepository : ICourseRepository
    {
        private UniversityContext _context;
        public EFCourseRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Course> Courses => _context.Courses;

        public Course DeleteCourse(int courseId)
        {
            Course dbEntry = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (dbEntry != null)
            {
                _context.Courses.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveCourse(Course course)
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
