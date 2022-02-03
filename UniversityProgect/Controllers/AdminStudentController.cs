using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Interfaces;

namespace UniversityProgect.Controllers
{
    public class AdminStudentController : Controller
    {
        private IStudentRepository _repository;

        public AdminStudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Edit(int studentId)
        {
            return View(_repository.Students.FirstOrDefault(p => p.StudentId == studentId));
        }
    }
}
