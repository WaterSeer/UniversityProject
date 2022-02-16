using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Services.Infrastructure.Dtos;

namespace UniversityProject.Services.Infrastructure.Interfaces
{
    public interface ICourseService
    {
        ServiceResponse<CourseDto> GetCourse(int id);

        ServiceResponse<IEnumerable<CourseDto>> GetCourses();

        Task<ServiceResponse<CourseDto>> UpdateCourseAsync(CourseDto course);        

        Task<ServiceResponse<CourseDto>> DeleteCourseAsync(int id);
    }
}
