using System;
using System.Linq;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;

namespace UniversityProject.Infrastucture.Data
{
    public class EFStudentRepository : IStudentRepository
    {
        private UniversityContext _context;
        public EFStudentRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Student> Students => _context.Students;

        public Student DeleteStudent(int studentId)
        {
            Student dbEntry = _context.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (dbEntry != null)
            {
                _context.Students.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveStudent(Student student)
        {
            if (student.StudentId == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                Student dbEntry = _context.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = student.FirstName;
                    dbEntry.FirstName = student.LastName;
                }
            }
            _context.SaveChanges();
        }
    }
}
