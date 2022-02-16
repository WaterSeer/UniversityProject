using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;

namespace UniversityProject.Infrastucture.Data
{
    public class EFGroupRepository : IRepository<Group>
    {
        private UniversityContext _context;
        public EFGroupRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Group> GetAll() => _context.Groups;


        public Group Get(int id)
        {
            return _context.Groups.FirstOrDefault(g => g.GroupId == id);
        }
        public Group Delete(int groupId)
        {
            Group dbEntry = _context.Groups.FirstOrDefault(g => g.GroupId == groupId);
            if (dbEntry != null)
            {
                _context.Groups.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public void Update(Group group)
        {
            if (group.GroupId == 0)
            {
                _context.Groups.Add(group);
            }
            else
            {
                Group dbEntry = _context.Groups.FirstOrDefault(g => g.GroupId == group.GroupId);
                if (dbEntry != null)
                {
                    dbEntry.Name = group.Name;
                    _context.Groups.Update(dbEntry);
                }
            }
            _context.SaveChanges();
        }

        public Task<Group> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Group> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
