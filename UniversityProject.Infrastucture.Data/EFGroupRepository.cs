using Microsoft.EntityFrameworkCore;
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
        public async Task<Group> DeleteAsync(int groupId)
        {
            Task<Group> dbEntry = _context.Groups.FirstOrDefaultAsync(g => g.GroupId == groupId);
            if (dbEntry != null)
            {
                _context.Groups.Remove(dbEntry.Result);
                await _context.SaveChangesAsync();
            }
            return await dbEntry;
        }

        public async Task<Group> UpdateAsync(Group group)
        {
            Group dbEntry = new Group();
            if (group.GroupId == 0)
            {
                await _context.Groups.AddAsync(group);
            }
            else
            {
                dbEntry = await _context.Groups.FirstOrDefaultAsync(g => g.GroupId == group.GroupId);
                if (dbEntry != null)
                {
                    dbEntry.Name = group.Name;                    
                }
            }
            await _context.SaveChangesAsync();
            return dbEntry;
        }
    }
}
