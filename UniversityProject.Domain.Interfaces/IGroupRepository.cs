using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;

namespace UniversityProject.Domain.Interfaces
{
    public interface IGroupRepository
    {
        IQueryable<Group> Groups { get; }

        void SaveGroup(Group group);

        Group DeleteGroup(int groupId);
    }
}
