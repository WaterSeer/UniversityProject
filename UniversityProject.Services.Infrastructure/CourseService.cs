using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProject.Services.Infrastructure
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly ILogger<CourseService> _logger;

        public CourseService(IRepository<Course> courseRepository, ILogger<CourseService> logger)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ServiceResponse<CourseDto> GetCourse(int id)
        {
            ServiceResponse<CourseDto> serviceResponse = new ServiceResponse<CourseDto>();
            var course = _courseRepository.Get(id);
            serviceResponse.Data = new CourseDto()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description
            };
            return serviceResponse;
        }

        public ServiceResponse<IEnumerable<CourseDto>> GetCourses()
        {
            ServiceResponse<IEnumerable<CourseDto>> serviceResponse = new();
            var courses = _courseRepository.GetAll();
            serviceResponse.Data = courses
                .Select(course => new CourseDto
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Description = course.Description
                });
            return serviceResponse;
        }

        public async Task<ServiceResponse<CourseDto>> UpdateCourseAsync(CourseDto course)
        {
            ServiceResponse<CourseDto> serviceResponse = new ServiceResponse<CourseDto>();
            var prevCourse = _courseRepository.GetAll().FirstOrDefault(c => c.CourseId == course.CourseId);
            if (prevCourse == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Course not found";
            }
            else
            {
                prevCourse.Name = course.Name;
                prevCourse.Description = course.Description;
                serviceResponse.Message = "Course updated";
                serviceResponse.Data = course;
                await _courseRepository.UpdateAsync(prevCourse);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CourseDto>> DeleteCourseAsync(int id)
        {
            ServiceResponse<CourseDto> serviceResponse = new ServiceResponse<CourseDto>();
            try
            {
                var course = _courseRepository.GetAll().FirstOrDefault(c => (int)c.CourseId == id);
                if (course != null)
                {
                    await _courseRepository.DeleteAsync(id);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Course not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, "Delete course error # {0}: {ExceptionMessage}", ex.Message, id);
            }
            return serviceResponse;
        }
    }
}
