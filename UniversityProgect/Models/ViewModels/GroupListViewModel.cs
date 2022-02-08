using System.Collections.Generic;
using UniversityProject.Domain.Core;

namespace UniversityProgect.Models.ViewModels
{
    public class GroupListViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
    }
}
