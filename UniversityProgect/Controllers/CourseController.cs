﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
                .OrderBy(o => o.CourseId)
            });               
        }
            

        public IActionResult Index1()
        {
            return View();
        }
        public ViewResult Edit(int courseId)
        {
            return View(_repository.Courses.FirstOrDefault(p => p.CourseId == courseId));
        }

    }
}