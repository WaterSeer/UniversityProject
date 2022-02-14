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

        public IEnumerable<StudentDto> GetStudents()
        {
            var students = _studentRepository.GetAll();
            var studentsDto = students
                .Select(student => new StudentDto
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                    //todo
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
                LastName = student.LastName
                //todo
            };
        }

        public void UpdateStudent(StudentDto student)
        {
            //_studentRepository.Update(student);
        }

        public StudentDto DeleteStudent(int id)
        {
            var student = _studentRepository.Get(id);
            _studentRepository.Delete(id);
            _studentRepository.SaveChanges();
            return new StudentDto()
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName
                //todo
            };
        }

        
    }
}
