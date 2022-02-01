using System.Collections.Generic;
using UniversityProgect.DataModel;

namespace UniversityProgect.Models.ViewModels
{
    public class StudentsListViewModel
    {
        public IEnumerable<Student> Students { get; set; }

        public int Id {get;set;}
    }
}
