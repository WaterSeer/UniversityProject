using System.Collections.Generic;
using System.Linq;
using UniversityProgect.DataModel;

namespace UniversityProgect.Models
{
    public class FakeUniversityRepository : IStudentRepository
    {
        public IQueryable<Student> Students => new List<Student>
        {
            new Student { FirstName = "Tom", StudentId = 1},
            new Student { FirstName = "Sara", StudentId = 2},
        }.AsQueryable<Student>();

        public IQueryable<Course> Courses => new List<Course>
        {
            new Course { CourseId = 1 , Name = "FN"},
            new Course { CourseId= 2 , Name = "SN"}
        }.AsQueryable<Course>();
    }
}
