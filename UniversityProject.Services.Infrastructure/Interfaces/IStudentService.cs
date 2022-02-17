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
        ServiceResponse<IEnumerable<StudentDto>> GetStudents();
        ServiceResponse<StudentDto> GetStudent(int id);
        Task<ServiceResponse<StudentDto>> UpdateStudentAsync(StudentDto student);
        Task<ServiceResponse<StudentDto>> DeleteStudentAsync(int id);
    }
}
