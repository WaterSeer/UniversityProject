using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;

namespace UniversityProject.Services.Infrastructure.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();

        Course GetCourse(int id);

        void UpdateCourse(Course course);

        Course DeleteCourse(int id);
    }
}
