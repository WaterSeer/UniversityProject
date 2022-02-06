using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.DataModel;
using UniversityProgect.Interfaces;
using UniversityProgect.Models.ViewModels;

namespace UniversityProgect.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _repository;

        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List()
        {
            return View(new CourseListViewModel
            {
                Courses = _repository.Courses
            });
        }

        public ViewResult Edit(int courseId)
        {
            return View(_repository.Courses.FirstOrDefault(p => p.CourseId == courseId));
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveCourse(course);
                TempData["message"] = $"{course.Name} has been saved";
                return RedirectToAction("List");
            }
            else
                return View(course);
        }

        [HttpPost]
        public IActionResult DeleteCourse(int courseId)
        {
            Course deleteCourse = _repository.DeleteCourse(courseId);
            if (deleteCourse != null)
            {
                TempData["message"] = $"{deleteCourse.Name} was deleted";
            }
            return RedirectToAction("List");
        }

    }
}
