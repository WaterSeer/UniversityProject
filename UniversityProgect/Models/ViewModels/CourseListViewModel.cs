using System.Collections.Generic;
using UniversityProject.Services.Infrastructure.Dtos;

namespace UniversityProgect.Models.ViewModels
{
    public class CourseListViewModel
    {
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}
