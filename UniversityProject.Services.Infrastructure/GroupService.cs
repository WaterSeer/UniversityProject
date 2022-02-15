using System;
using System.Collections.Generic;
using System.Linq;
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
        

        public GroupDto DeleteGroup(int id)
        {
            var group = _groupRepository.Get(id);
            _groupRepository.Delete(id);
            return new GroupDto()
            {
                GroupId = group.GroupId,
                Name = group.Name,
                CourseId = group.CourseId is null ? 0 : group.CourseId.Value
            };
        }

        public GroupDto GetGroup(int id)
        {
            var group = _groupRepository.Get(id);
            return new GroupDto()
            {
                GroupId = group.GroupId,
                Name = group.Name,
                CourseId = group.CourseId is null ? 0 : group.CourseId.Value
            };
        }

        public IEnumerable<GroupDto> GetGroups()
        {
            var groups = _groupRepository.GetAll();
            var groupsDto = groups
                .Select(group => new GroupDto
                {
                    GroupId = group.GroupId,
                    Name = group.Name,
                    CourseId = group.CourseId == null ? 0 : group.CourseId.Value
                }).ToList();
            return groupsDto;
                
        }

        public void UpdateGroup(GroupDto group)
        {
             var prevGroup = _groupRepository.GetAll().FirstOrDefault(g => g.GroupId == group.GroupId);
            if(prevGroup != null)
            {
                prevGroup.GroupId = group.GroupId;
                prevGroup.Name = group.Name;
                prevGroup.CourseId = group.CourseId;     
                _groupRepository.Update(prevGroup);
            }
        }
    }
}
