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
        ServiceResponse<IEnumerable<GroupDto>> GetGroups();

        ServiceResponse<GroupDto> GetGroup(int id);

        Task<ServiceResponse<GroupDto>> UpdateGroupAsync(GroupDto group);

        Task<ServiceResponse<GroupDto>> DeleteGroupAsync(int id);

    }
}
