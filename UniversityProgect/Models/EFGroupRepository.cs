using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProgect.DataModel;
using UniversityProgect.Interfaces;

namespace UniversityProgect.Models
{
    public class EFGroupRepository : IGroupRepository
    {
        private UniversityContext _context;
        public EFGroupRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Group> Groups => _context.Groups;

        public void SaveGroup(Group group)
        {
            if (group.GroupId == 0)
            {
                _context.Groups.Add(group);
            }
            else
            {
                Group dbEntry = _context.Groups.FirstOrDefault(g => g.GroupId == group.GroupId);    
                if(dbEntry != null)
                {
                    dbEntry.Name = group.Name;
                }
            }
            _context.SaveChanges();
        }
    }
}
