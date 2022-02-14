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
        IEnumerable<CourseDto> GetCourses();

        CourseDto GetCourse(int id);

        void UpdateCourse(CourseDto course);

        CourseDto DeleteCourse(int id);
    }
}
