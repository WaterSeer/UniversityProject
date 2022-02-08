using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Domain.Core
{
    [Table("COURSES")]
    public partial class Course
    {
        public Course()
        {
            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("COURSE_ID", TypeName = "int")]
        public long CourseId { get; set; }
        [Required]
        [Column("NAME", TypeName = "NVARCHAR(25)")]
        public string Name { get; set; }
        [Column("DESCRIPTION", TypeName = "NVARCHAR(300)")]
        public string Description { get; set; }

        [InverseProperty(nameof(Group.Course))]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
