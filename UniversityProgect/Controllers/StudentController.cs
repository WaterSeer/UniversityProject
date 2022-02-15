using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Models.ViewModels;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProgect.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _service;
        private IGroupService _groupService;
        public int PageSize = 10;

        public StudentController(IStudentService servise, IGroupService groupService)
        {
            _service = servise;
            _groupService = groupService;
        }

        [HttpPost]
        public ViewResult List(int groupId)
        {
            return View(new StudentsListViewModel
            {
                Students = _service.GetStudents().Where(S => S.GroupId == groupId),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = _service.GetStudents().Count(),
                    TotalItems = _service.GetStudents().Count()
                }
            });
        }

        public ViewResult List(string category, int productPage = 1)
        {
            string groupCategory = "1";
            if (category != null)
                groupCategory = _groupService.GetGroups().FirstOrDefault(g => g.Name == category).GroupId.ToString();
            var a = new StudentsListViewModel
            {
                Students = _service.GetStudents()
                 .Where(p => category == null || groupCategory == category)
                 .Skip((productPage - 1) * PageSize)
                 .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _service.GetStudents().Count()
                },
                CurrentCategory = category
            };
            return View(new StudentsListViewModel
            {
                Students = _service.GetStudents()
                .Where(p => category == null || groupCategory == category)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _service.GetStudents().Count()
                },
                CurrentCategory = category
            });
        }

        public ViewResult Edit(int studentId)
        {
            return View(_service.GetStudents().FirstOrDefault(s => s.StudentId == studentId));
        }

        [HttpPost]
        public IActionResult Edit(StudentDto student)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateStudent(student);
                TempData["message"] = $"{student.FirstName} {student.LastName} has been saved";
                return RedirectToAction("List");
            }
            else
                return View(student);
        }

        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            StudentDto deleteStudent = _service.DeleteStudent(studentId);
            if (deleteStudent != null)
            {
                TempData["message"] = $"{deleteStudent.FirstName} {deleteStudent.LastName} was deleted";
            }
            return RedirectToAction("List");
        }
    }
}
