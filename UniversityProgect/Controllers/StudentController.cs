using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using UniversityProgect.Models.ViewModels;
using UniversityProject.Domain.Core;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProgect.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        private readonly IGroupService _groupService;
        private readonly ILogger<StudentController> _logger;
        public int PageSize = 10;

        public StudentController(IStudentService service, IGroupService groupService, ILogger<StudentController> logger)
        {
            _service = service;
            _groupService = groupService;
            _logger = logger;
        }

        [HttpPost]
        public ViewResult List(int groupId)
        {
            return View(new StudentsListViewModel
            {
                Students = _service.GetStudents().Data.Where(S => S.GroupId == groupId),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = _service.GetStudents().Data.Count(),
                    TotalItems = _service.GetStudents().Data.Count()
                }
            });
        }

        public ViewResult List(string category, int productPage = 1)
        {
            string groupCategory = "1";
            if (category != null)
                groupCategory = _groupService.GetGroups().Data.FirstOrDefault(g => g.Name == category).GroupId.ToString();
            var a = new StudentsListViewModel
            {
                Students = _service.GetStudents().Data
                 .Where(p => category == null || groupCategory == category)
                 .Skip((productPage - 1) * PageSize)
                 .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _service.GetStudents().Data.Count()
                },
                CurrentCategory = category
            };
            var b = View(new StudentsListViewModel
            {
                Students = _service.GetStudents().Data
                .Where(p => category == null || groupCategory == category)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _service.GetStudents().Data.Count()
                },
                CurrentCategory = category
            });
            return b;
        }

        public ViewResult Edit(int studentId)
        {
            return View(_service.GetStudents().Data.FirstOrDefault(s => s.StudentId == studentId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentDto student)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateStudentAsync(student);
                TempData["message"] = $"{student.FirstName} {student.LastName} has been saved";
                _logger.LogInformation("{0} has been edited.", student.LastName);
                return RedirectToAction("List");
            }
            else
                return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            var deleteStudent = await _service.DeleteStudentAsync(studentId);
            if (deleteStudent.Data != null)
            {
                TempData["message"] = $"{deleteStudent.Data.FirstName} {deleteStudent.Data.LastName} was deleted";
                _logger.LogInformation("{0} has been deleted.", deleteStudent.Data.LastName);
            }
            return RedirectToAction("List");
        }
    }
}
