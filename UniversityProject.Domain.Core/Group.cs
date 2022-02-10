using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityProject.Domain.Core
{
    [Table("GROUPS")]
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        [Column("GROUP_ID", TypeName = "int")]
        public long GroupId { get; set; }
        [Column("COURSE_ID", TypeName = "int")]
        public long? CourseId { get; set; }
        [Required]
        [Column("NAME", TypeName = "nvarchar(25)")]
        public string Name { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Groups")]
        public virtual Course Course { get; set; }
        [InverseProperty(nameof(Student.Group))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
