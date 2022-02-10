using System.Collections.Generic;
using UniversityProject.Domain.Core;

namespace UniversityProgect.Models.ViewModels
{
    public class StudentsListViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get;set; }
    }
}
