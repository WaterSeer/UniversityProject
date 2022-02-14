using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Services.Infrastructure.Dtos;

namespace UniversityProject.Services.Infrastructure.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> GetGroups();

        GroupDto GetGroup(int id);

        void UpdateGroup(GroupDto group);

        GroupDto DeleteGroup(int id);

    }
}
