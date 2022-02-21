using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProject.Services.Infrastructure
{
    public class GroupService : IGroupService
    {

        private readonly IRepository<Group> _groupRepository;

        public GroupService(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public ServiceResponse<GroupDto> GetGroup(int id)
        {
            ServiceResponse<GroupDto> serviceResponse = new ServiceResponse<GroupDto>();
            var group = _groupRepository.Get(id);
            serviceResponse.Data = new GroupDto()
            {
                GroupId = group.GroupId,
                Name = group.Name,
                CourseId = group.CourseId is null ? 0 : group.CourseId.Value
            };
            return serviceResponse;
        }

        public ServiceResponse<IEnumerable<GroupDto>> GetGroups()
        {
            ServiceResponse<IEnumerable<GroupDto>> serviceResponse = new ServiceResponse<IEnumerable<GroupDto>>();
            var groups = _groupRepository.GetAll();
            serviceResponse.Data = groups
                .Select(group => new GroupDto
                {
                    GroupId = group.GroupId,
                    Name = group.Name,
                    CourseId = group.CourseId == null ? 0 : group.CourseId.Value
                }).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GroupDto>> UpdateGroupAsync(GroupDto group)
        {
            ServiceResponse<GroupDto> serviceResponse = new ServiceResponse<GroupDto>();
            var prevGroup = _groupRepository.GetAll().FirstOrDefault(g => g.GroupId == group.GroupId);
            if (prevGroup == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Group not found";
            }
            else
            {
                prevGroup.Name = group.Name;
                serviceResponse.Message = "Group updated";
                serviceResponse.Data = group;
                await _groupRepository.UpdateAsync(prevGroup);
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GroupDto>> DeleteGroupAsync(int id)
        {
            ServiceResponse<GroupDto> serviceResponse = new ServiceResponse<GroupDto>();
            try
            {
                var group = _groupRepository.GetAll().FirstOrDefault(g => g.GroupId == id);
                if (group != null)
                {
                    await _groupRepository.DeleteAsync(id);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Group not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
