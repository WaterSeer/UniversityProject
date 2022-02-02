using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProgect.DataModel;

namespace UniversityProgect.Interfaces
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
    }
}
