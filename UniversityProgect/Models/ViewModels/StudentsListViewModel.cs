using System.Collections.Generic;
using UniversityProject.Services.Infrastructure.Dtos;

namespace UniversityProgect.Models.ViewModels
{
    public class StudentsListViewModel
    {
        public IEnumerable<StudentDto> Students { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
