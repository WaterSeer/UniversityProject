using System.Collections.Generic;
using UniversityProgect.DataModel;

namespace UniversityProgect.Models.ViewModels
{
    public class CourseListViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}
