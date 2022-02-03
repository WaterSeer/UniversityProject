using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Interfaces;

namespace UniversityProgect.Controllers
{
    public class AdminCourseController : Controller
    {
        private ICourseRepository _repository;

        public AdminCourseController(ICourseRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Edit(int courseId)
        {
            return View(_repository.Courses.FirstOrDefault(p => p.CourseId == courseId));
        }

    }
}
