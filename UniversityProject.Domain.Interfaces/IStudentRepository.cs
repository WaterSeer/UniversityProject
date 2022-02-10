using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;

namespace UniversityProject.Domain.Interfaces
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }

        void SaveStudent(Student student);

        Student DeleteStudent(Student);
    }
}
