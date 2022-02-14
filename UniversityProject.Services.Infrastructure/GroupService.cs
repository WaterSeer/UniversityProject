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
            _groupRepository.SaveChanges();
            return new GroupDto()
            {
                GroupId = group.GroupId,
                Name = group.Name,
                //todo
            };
        }

        public GroupDto GetGroup(int id)
        {
            var group = _groupRepository.Get(id);
            return new GroupDto()
            {
                GroupId = group.GroupId,
                Name = group.Name,
                //todo
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
                    //todo
                }).ToList();
            return groupsDto;
                
        }

        public void UpdateGroup(GroupDto group)
        {
            //_groupRepository.Update(group);
        }
    }
}
