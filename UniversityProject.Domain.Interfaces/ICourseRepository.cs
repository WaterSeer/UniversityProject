using System;
using System.Linq;
using UniversityProject.Domain.Core;

namespace UniversityProject.Domain.Interfaces
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }

        void SaveCourse(Course course);

        Course DeleteCourse(int courseId);
    }
}
