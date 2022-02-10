using System;
using System.Linq;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;

namespace UniversityProject.Infrastucture.Data
{
    public class EFGroupRepository : IGroupRepository
    {
        private UniversityContext _context;
        public EFGroupRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Group> Groups => _context.Groups;

        public Group DeleteGroup(int groupId)
        {
            Group dbEntry = _context.Groups.FirstOrDefault(g => g.GroupId == groupId);
            if (dbEntry != null)
            {
                _context.Groups.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveGroup(Group group)
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
                }
            }
            _context.SaveChanges();
        }
    }
}
