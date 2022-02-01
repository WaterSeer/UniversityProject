using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityProgect.DataModel;
using UniversityProgect.Models;

namespace UniversityProgect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UniversityContext _context;

        public HomeController(ILogger<HomeController> logger, UniversityContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            UnViewModel model = new UnViewModel();
            model.Courses = _context.Courses.ToList();  
            model.Students = _context.Students.ToList();  
            model.Groups = _context.Groups.ToList();
            return View(model);
        }

        [HttpPost]       
        public IActionResult Simple([FromBody] string value)
        {
            return View();
        }


            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class UnViewModel
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Group> Groups { get; set; } 

    }
}
