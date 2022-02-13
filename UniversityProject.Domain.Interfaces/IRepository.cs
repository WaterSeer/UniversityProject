using System.Linq;

namespace UniversityProject.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T Get(int id);

        void Update(T entity);

        T Delete(int id);

        void SaveChanges();
    }
}
