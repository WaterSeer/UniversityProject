﻿using System.Linq;
using UniversityProgect.DataModel;

namespace UniversityProgect.Models
{
    public class EFStudentRepository : IStudentRepository
    {
        private UniversityContext _context;
        public EFStudentRepository(UniversityContext context)
        {
            _context = context;
        }
        public IQueryable<Student> Students => _context.Students;
    }
}
