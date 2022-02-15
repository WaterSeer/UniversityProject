using System.Linq;
using System.Threading.Tasks;

namespace UniversityProject.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T Get(int id);

        Task<T> GetAsync(int id);

        void Update(T entity);

        T Delete(int id);

        Task<T> DeleteAsync(int id);
    }
}
