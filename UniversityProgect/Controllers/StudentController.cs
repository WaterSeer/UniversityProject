using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Models.ViewModels;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProgect.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _servise;
        public int PageSize = 10;

        public StudentController(IStudentService service)
        {
            _servise = service;
        }

        [HttpPost]
        public ViewResult List(int groupId)
        {
            return View(new StudentsListViewModel
            {
                Students = _servise.GetStudents().Where(S => S.GroupId == groupId),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = _servise.GetStudents().Count(),
                    TotalItems = _servise.GetStudents().Count()
                }
            });
        }

        public ViewResult List(string category, int productPage = 1)
        {
            return View(new StudentsListViewModel
            {
                Students = _servise.GetStudents()
                .Where(p => category == null || p.Group.Name == category)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _servise.GetStudents().Count()
                },
                CurrentCategory = category
            });
        }

        public ViewResult Edit(int studentId)
        {
            return View(_servise.GetStudents().FirstOrDefault(s => s.StudentId == studentId));
        }

        [HttpPost]
        public IActionResult Edit(StudentDto student)
        {
            if (ModelState.IsValid)
            {
                _servise.UpdateStudent(student);
                TempData["message"] = $"{student.FirstName} {student.LastName} has been saved";
                return RedirectToAction("List");
            }
            else
                return View(student);
        }

        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            StudentDto deleteStudent = _servise.DeleteStudent(studentId);
            if (deleteStudent != null)
            {
                TempData["message"] = $"{deleteStudent.FirstName} {deleteStudent.LastName} was deleted";
            }
            return RedirectToAction("List");
        }
    }
}
