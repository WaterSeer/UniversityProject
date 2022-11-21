using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniversityProgect.Models.ViewModels;
using UniversityProject.Domain.Core;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProgect.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICourseService service, ILogger<CourseController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        public ViewResult List()
        {
            return View(new CourseListViewModel
            {
                Courses = _service.GetCourses().Data
            });
        }

        public ViewResult Edit(int courseId)
        {
            return View(_service.GetCourses().Data.FirstOrDefault(p => p.CourseId == courseId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseDto course)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateCourseAsync(course);
                TempData["message"] = $"{course.Name} has been saved";
                _logger.LogInformation("{0} has been edited.", course.Name);
                return RedirectToAction("List");
            }
            else
                return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var deleteCourse = await _service.DeleteCourseAsync(courseId);
            if (deleteCourse.Data != null)
            {
                TempData["message"] = $"{deleteCourse.Data.Name} was deleted";
                _logger.LogInformation("{0} has been deleted.", deleteCourse.Data.Name);
            }
            return RedirectToAction("List");
        }

    }
}
