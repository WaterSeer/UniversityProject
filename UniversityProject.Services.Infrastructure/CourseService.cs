using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProject.Services.Infrastructure
{
    public class CourseService : ICourseService
    {

        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Course DeleteCourse(int id)
        {
            var course = _courseRepository.Get(id);
            _courseRepository.Delete(id);
            _courseRepository.SaveChanges();
            return course;
        }

        public Course GetCourse(int id)
        {
            return _courseRepository.Get(id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _courseRepository.GetAll();
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }
    }
}
