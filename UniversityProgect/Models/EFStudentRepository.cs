using System.Linq;
using UniversityProgect.DataModel;
using UniversityProgect.Interfaces;

namespace UniversityProgect.Models
{
    public class EFStudentRepository : IStudentRepository
    {
        private UniversityContext _context;
        public EFStudentRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Student> Students => _context.Students;

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
