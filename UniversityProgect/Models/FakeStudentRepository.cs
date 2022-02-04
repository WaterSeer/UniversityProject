using System.Collections.Generic;
using System.Linq;
using UniversityProgect.DataModel;
using UniversityProgect.Interfaces;

namespace UniversityProgect.Models
{
    public class FakeStudentRepository// : IStudentRepository
    {
        public IQueryable<Student> Students => new List<Student>
        {
            new Student { FirstName = "Tom", StudentId = 1},
            new Student { FirstName = "Sara", StudentId = 2},
        }.AsQueryable<Student>();
    }
}
