using System.Collections.Generic;
using UniversityProject.Services.Infrastructure.Dtos;

namespace UniversityProgect.Models.ViewModels
{
    public class GroupListViewModel
    {
        public IEnumerable<GroupDto> Groups { get; set; }
    }
}
