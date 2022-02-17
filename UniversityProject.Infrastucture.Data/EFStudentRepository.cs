using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;

namespace UniversityProject.Infrastucture.Data
{
    public class EFStudentRepository : IRepository<Student>
    {
        private UniversityContext _context;
        public EFStudentRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Student> GetAll() => _context.Students;

        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == id);
        }
        public async Task<Student> DeleteAsync(int studentId)
        {
            Task<Student> dbEntry = _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (dbEntry != null)
            {
                _context.Students.Remove(dbEntry.Result);
                _context.SaveChanges();
            }
            return await dbEntry;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            Student dbEntry = new Student();
            if (student.StudentId == 0)
            {
                await _context.Students.AddAsync(student);
            }
            else
            {
                dbEntry = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == student.StudentId);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = student.FirstName;
                    dbEntry.LastName = student.LastName;
                }
            }
            await _context.SaveChangesAsync();
            return dbEntry; 
        }        
    }
}
