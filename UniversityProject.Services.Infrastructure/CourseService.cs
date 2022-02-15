using System.Collections.Generic;
using System.Linq;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Services.Infrastructure.Dtos;
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

        public CourseDto DeleteCourse(int id)
        {
            var course = _courseRepository.Get(id);
            _courseRepository.Delete(id);
            return new CourseDto()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description
            };
        }

        public CourseDto GetCourse(int id)
        {
            var course = _courseRepository.Get(id);
            return new CourseDto()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description
            };
        }

        public IEnumerable<CourseDto> GetCourses()
        {
            var courses = _courseRepository.GetAll();
            var coursesDto = courses
                .Select(course => new CourseDto
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Description = course.Description
                }).ToList();
            return coursesDto;
        }

        public void UpdateCourse(CourseDto course)
        {
            var prevCourse = _courseRepository.GetAll().FirstOrDefault(c => c.CourseId == course.CourseId);
            if (prevCourse != null)
            {
                prevCourse.Name = course.Name;
                prevCourse.Description = course.Description;
                prevCourse.CourseId = course.CourseId;
                _courseRepository.Update(prevCourse);
            }
                  
        }
    }
}
