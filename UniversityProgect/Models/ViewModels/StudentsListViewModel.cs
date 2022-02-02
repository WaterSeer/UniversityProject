using System.Collections.Generic;
using UniversityProgect.DataModel;

namespace UniversityProgect.Models.ViewModels
{
    public class StudentsListViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get;set; }
    }
}
