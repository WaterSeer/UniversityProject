using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityProgect.Models
{
    public class SelectedStudents
    {
        public string Course { get; set; }
        public string Group { get; set; }
        public void Clear()
        {
            Course = null;
            Group = null;
        }
    }
}
