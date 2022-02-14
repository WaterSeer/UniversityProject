using System.Collections.Generic;

namespace UniversityProject.Services.Infrastructure.Dtos
{
    public class GroupDto
    {
        public long GroupId { get; set; }

        public long CourseId { get; set; }

        public string Name { get; set; }

        public CourseDto Course { get; set; }

        public IEnumerable<StudentDto> Students { get; set; }
    }
}
