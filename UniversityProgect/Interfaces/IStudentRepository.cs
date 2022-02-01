using System.Linq;
using UniversityProgect.DataModel;

namespace UniversityProgect.Interfaces
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }            
    }
}
