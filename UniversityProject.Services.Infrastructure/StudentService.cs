using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Infrastucture.Data.Data;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProject.Services.Infrastructure
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
                
        public IStudentRepository StudentRepository { get; }

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }       

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.Get(id);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepository.Get(id);
            _studentRepository.Delete(student);
            _studentRepository.SaveChange();
        }

        
    }
}
