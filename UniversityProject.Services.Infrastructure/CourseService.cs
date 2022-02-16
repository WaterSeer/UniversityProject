﻿using Microsoft.EntityFrameworkCore;
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

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        //public CourseDto DeleteCourse(int id)
    //    {
      //      var course = _courseRepository.Get(id);
      //      _courseRepository.Delete(id);
       //     return new CourseDto()
        //    {
         //       CourseId = course.CourseId,
          //      Name = course.Name,
            //    Description = course.Description
      //      };
    //    }

        public async Task<ServiceResponse<CourseDto>> DeleteCourseAsync(int id)
        {
            ServiceResponse<CourseDto> serviceResponse = new ServiceResponse<CourseDto>();
            try
            {
                var course = await _courseRepository.GetAsync(id);
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
            }
            return serviceResponse;                
        }

        public Task<ServiceResponse<CourseDto>> GetCourseAsync(int id)
        {
            throw new NotImplementedException();
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

        //public async Task<ServiceResponse<CourseDto>> GetCourseAsync(int id)
        //{
        //    ServiceResponse<CourseDto> result = new ServiceResponse<CourseDto>();
        //    var course = await _courseRepository.GetAsync(id);
        //    result.Data.CourseId = course.CourseId;
        //    result.Data.Name = course.Name;
        //    result.Data.Description = course.Description;
        //    return result;
        //}

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

        public Task<ServiceResponse<List<CourseDto>>> GetCoursesAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<ServiceResponse<List<CourseDto>>> GetCoursesAsync()
        //{
        //    ServiceResponse<List<CourseDto>> serviceResponse = new ServiceResponse<List<CourseDto>>();
        //    var courses = _courseRepository.GetAll();
        //    //serviceResponse.Data = await courses.  //ToListAsync();
        //    return serviceResponse;
        //}


        //public void UpdateCourse(CourseDto course)
        //{
        //    var prevCourse = _courseRepository.GetAll().FirstOrDefault(c => c.CourseId == course.CourseId);
        //    if (prevCourse != null)
        //    {
        //        prevCourse.Name = course.Name;
        //        prevCourse.Description = course.Description;                
        //        _courseRepository.Update(prevCourse);
        //    }                  
        //}

        public async Task<ServiceResponse<CourseDto>> UpdateCourseAsync(CourseDto course)
        {
            ServiceResponse<CourseDto> serviceResponse = new ServiceResponse<CourseDto>();
            var prevCourse = await _courseRepository.GetAll().FirstOrDefaultAsync(c => c.CourseId == course.CourseId);
            if(prevCourse == null)
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
                _courseRepository.Update(prevCourse);
            }
            return serviceResponse;
        }
    }
}
