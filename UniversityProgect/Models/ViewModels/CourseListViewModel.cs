using System.Collections.Generic;
using UniversityProject.Domain.Core;

namespace UniversityProgect.Models.ViewModels
{
    public class CourseListViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}
