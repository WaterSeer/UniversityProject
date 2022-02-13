using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProject.Services.Infrastructure
{
    public class StudentService : Interfaces.IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
              

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

        public Student DeleteStudent(int id)
        {
            var student = _studentRepository.Get(id);
            _studentRepository.Delete(id);
            _studentRepository.SaveChanges();
            return student;
        }

        
    }
}
