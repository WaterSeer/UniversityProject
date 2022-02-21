using System.Linq;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T Get(int id);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(int id);
    }
}
