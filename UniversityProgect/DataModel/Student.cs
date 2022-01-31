using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace UniversityProgect.DataModel
{
    [Table("STUDENTS")]
    public partial class Student
    {
        [Key]
        [Column("STUDENT_ID", TypeName = "int")]
        public long StudentId { get; set; }
        [Column("GROUP_ID", TypeName = "int")]
        public long? GroupId { get; set; }
        [Required]
        [Column("FIRST_NAME", TypeName = "nvarchar(25)")]
        public string FirstName { get; set; }
        [Required]
        [Column("LAST_NAME", TypeName = "nvarchar(25)")]
        public string LastName { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Students")]
        public virtual Group Group { get; set; }
    }
}
