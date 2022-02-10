using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProject.Services.Infrastructure
{
    internal interface IUnitOfWork
    {
        void ChangeDatabase(string database);

        //IGenericRepository<TEntity> GerRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;

        int SaveChanges(bool ensureAutoHistory = false);

        //Task<int> SaveChangesAsync(bool ensureAutoHistory = false);

        //int ExecuteSqlCommand(string sql, params object[] parameters);

        //IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class;

        //void TrackGraph(object rootEntity, Action<EntityEntryGraphNode> callback);
    }
}
