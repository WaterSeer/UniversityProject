using System.Collections.Generic;

namespace UniversityProject.Services.Infrastructure.Dtos
{
    public class CourseDto
    {

        public long CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<GroupDto> Groups { get; set; }
    }
}
