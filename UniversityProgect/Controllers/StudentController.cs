using Microsoft.AspNetCore.Mvc;
using UniversityProgect.Models;

namespace UniversityProgect.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List() => View(_repository.Students);
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
