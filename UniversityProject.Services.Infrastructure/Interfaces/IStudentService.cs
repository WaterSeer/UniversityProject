using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Services.Infrastructure.Dtos;

namespace UniversityProject.Services.Infrastructure.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDto> GetStudents();
        StudentDto GetStudent(int id);
        void UpdateStudent(StudentDto student);
        StudentDto DeleteStudent(int id);
    }
}
