using Microsoft.AspNetCore.Mvc;
using UniversityProgect.Interfaces;

namespace UniversityProgect.Controllers
{
    public class SelectCourseController : Controller
    {
        private ICourseRepository _repository;

        public SelectCourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        

        public IActionResult Index()
        {
            return View();
        }
    }
}
