using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProgect.DataModel;

namespace UniversityProgect.Interfaces
{
    public interface IGroupRepository
    {
        IQueryable<Group> Groups { get; }

        void SaveGroup(Group group);

        Group DeleteGroup(int groupId);
    }
}
