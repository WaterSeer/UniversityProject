using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProject.Services.Infrastructure
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;              

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }       

        private StudentDto Get(Student student)
        {
            return new StudentDto()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupId = student.GroupId is null ? 0 : student.GroupId.Value                
            };
        }

        public IEnumerable<StudentDto> GetStudents()
        {
            var students = _studentRepository.GetAll();
            var studentsDto = students
                .Select(student => new StudentDto
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    GroupId = student.GroupId == null ? 0 : student.GroupId.Value

                }).ToList();
            return studentsDto;
        }

        public StudentDto GetStudent(int id)
        {
            var student = _studentRepository.Get(id);
            return new StudentDto()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupId = student.GroupId is null ? 0 : student.GroupId.Value
            };
        }

        public void UpdateStudent(StudentDto student)
        {
            var prevStudent = _studentRepository.GetAll().FirstOrDefault(s => s.StudentId == student.StudentId);
            if (prevStudent != null)
            {
                prevStudent.FirstName = student.FirstName;
                prevStudent.LastName = student.LastName;
                prevStudent.GroupId = student.GroupId;
                _studentRepository.Update(prevStudent);
            }
        }

        public StudentDto DeleteStudent(int id)
        {
            var student = _studentRepository.Get(id);
            _studentRepository.Delete(id);
            return new StudentDto()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                GroupId = student.GroupId is null ? 0 : student.GroupId.Value
            };
        }

        
    }
}
