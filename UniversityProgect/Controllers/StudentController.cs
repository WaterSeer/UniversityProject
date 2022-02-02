using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Interfaces;
using UniversityProgect.Models.ViewModels;

namespace UniversityProgect.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _repository;
        public int PageSize = 10;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            //return View(_repository.Students.OrderBy(o => o.LastName)
            //    .Skip((productPage - 1) * PageSize)
            //    .Take(PageSize));

            return View(new StudentsListViewModel
            {
                Students = _repository.Students
                .Where(p => category == null || p.Group.Name == category)
                .OrderBy(o => o.LastName)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Students.Count()
                },
                CurrentCategory = category
            });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
