using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Infrastucture.Data;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProject.Services.Infrastructure
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IRepository<Student> studentRepository, ILogger<StudentService> logger)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private ServiceResponse<StudentDto> Get(Student student)
        {
            ServiceResponse<StudentDto> serviceResponse = new ServiceResponse<StudentDto>();
            serviceResponse.Data = new StudentDto()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupId = student.GroupId is null ? 0 : student.GroupId.Value
            };
            return serviceResponse;
        }

        public ServiceResponse<IEnumerable<StudentDto>> GetStudents()
        {
            ServiceResponse<IEnumerable<StudentDto>> serviceResponse = new ServiceResponse<IEnumerable<StudentDto>>();
            var students = _studentRepository.GetAll();
            serviceResponse.Data = students
                .Select(student => new StudentDto
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    GroupId = student.GroupId == null ? 0 : student.GroupId.Value

                }).ToList();
            return serviceResponse;
        }

        public ServiceResponse<StudentDto> GetStudent(int id)
        {
            ServiceResponse<StudentDto> serviceResponse = new ServiceResponse<StudentDto>();
            var student = _studentRepository.Get(id);
            serviceResponse.Data = new StudentDto()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupId = student.GroupId is null ? 0 : student.GroupId.Value
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<StudentDto>> UpdateStudentAsync(StudentDto student)
        {
            ServiceResponse<StudentDto> serviceResponse = new ServiceResponse<StudentDto>();
            var prevStudent = _studentRepository.GetAll().FirstOrDefault(s => s.StudentId == student.StudentId);
            if (prevStudent == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Student not found";
            }
            else
            {
                prevStudent.FirstName = student.FirstName;
                prevStudent.LastName = student.LastName;
                serviceResponse.Message = "Student updated";
                serviceResponse.Data = student;
                await _studentRepository.UpdateAsync(prevStudent);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<StudentDto>> DeleteStudentAsync(int id)
        {
            ServiceResponse<StudentDto> serviceResponse = new ServiceResponse<StudentDto>();
            try
            {
                var student = _studentRepository.GetAll().FirstOrDefault(s => (int)s.StudentId == id);
                if (student != null)
                {
                    await _studentRepository.DeleteAsync(id);
                }
                else
                {
                    serviceResponse.Message = "Student not found";
                    serviceResponse.Success = false;
                }
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, "Delete student error # {0}: {ExceptionMessage}", ex.Message, id);
            }
            return serviceResponse;
        }
    }
}
