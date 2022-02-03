using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.DataModel;
using UniversityProgect.Infrastructure;
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

        public RedirectToActionResult SelectCourse(int courseId, string returnUrl)
        {
            Course course = _repository.Courses.FirstOrDefault(c => c.CourseId == courseId);
            if(course != null)
            {
                HttpContext.Session.SetJson("SelectedCourse", courseId);                
            }
            return RedirectToAction("List(" + courseId.ToString() + ")" , new { returnUrl });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
