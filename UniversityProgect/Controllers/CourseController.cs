﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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
                TempData["message"] = $"{course.Name} has been saved_1";
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
            }
            return RedirectToAction("List");
        }

    }
}
