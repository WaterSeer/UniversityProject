using System.Linq;
using UniversityProgect.DataModel;

namespace UniversityProgect.Models
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }            
    }
}
