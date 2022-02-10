using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;

namespace UniversityProject.Services.Infrastructure
{
    public class UnitOfWork
    {
        private ICourseRepository _courseRepository;
        private IGroupRepository _groupRepository;
        private IStudentRepository _studentRepository;

        public ICourseRepository CourseRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IStudentRepository StudentRepository { get; }

        public UnitOfWork(ICourseRepository courseRepository, IGroupRepository groupRepository, IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
        }

        public void SaveStudent(Student student)
        {
            _studentRepository.SaveStudent(student);
        }

        public void DeleteStudent(int student)
        {
            _studentRepository.DeleteStudent(student);
        }
    }
}
