using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;

namespace UniversityProject.Services.Infrastructure.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetGroups();

        Group GetGroup(int id);

        void UpdateGroup(Group group);

        Group DeleteGroup(int id);

    }
}
