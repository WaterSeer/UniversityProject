using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProgect.DataModel;
using UniversityProgect.Interfaces;

namespace UniversityProgect.Models
{
    public class EFCourseRepository : ICourseRepository
    {
        private UniversityContext _context;
        public EFCourseRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Course> Courses => _context.Courses;

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
