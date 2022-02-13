using System;
using System.Collections.Generic;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
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

        public Group DeleteGroup(int id)
        {
            var group = _groupRepository.Get(id);
            _groupRepository.Delete(id);
            _groupRepository.SaveChanges();
            return group;
        }

        public Group GetGroup(int id)
        {
            return _groupRepository.Get(id);
        }

        public IEnumerable<Group> GetGroups()
        {
            return _groupRepository.GetAll();
        }

        public void UpdateGroup(Group group)
        {
            _groupRepository.Update(group);
        }
    }
}
