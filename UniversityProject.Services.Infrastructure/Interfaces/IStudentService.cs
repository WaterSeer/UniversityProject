using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;

namespace UniversityProject.Services.Infrastructure.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
