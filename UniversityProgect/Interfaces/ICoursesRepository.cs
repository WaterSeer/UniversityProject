using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProgect.DataModel;

namespace UniversityProgect.Interfaces
{
    interface ICoursesRepository
    {
        IQueryable<Course> Courses { get; }
    }
}
