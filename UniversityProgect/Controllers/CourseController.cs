using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Models.ViewModels;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProgect.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        public ViewResult List()
        {
            return View(new CourseListViewModel
            {
                Courses = _service.GetCourses()
            });
        }

        public ViewResult Edit(int courseId)
        {
            return View(_service.GetCourses().FirstOrDefault(p => p.CourseId == courseId));
        }

        [HttpPost]
        public IActionResult Edit(CourseDto course)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCourse(course);
                TempData["message"] = $"{course.Name} has been saved";
                return RedirectToAction("List");
            }
            else
                return View(course);
        }

        [HttpPost]
        public IActionResult DeleteCourse(int courseId)
        {
            CourseDto deleteCourse = _service.DeleteCourse(courseId);
            if (deleteCourse != null)
            {
                TempData["message"] = $"{deleteCourse.Name} was deleted";
            }
            return RedirectToAction("List");
        }

    }
}
