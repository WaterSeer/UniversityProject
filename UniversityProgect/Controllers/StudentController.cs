using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Models.ViewModels;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;
using UniversityProject.Services.Infrastructure;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProgect.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _servise;
        private IStudentRepository _repository;
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
                Students = _repository.Students.Where(S => S.GroupId == groupId),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = _repository.Students.Count(),
                    TotalItems = _repository.Students.Count()
                }
            });
        }

        public ViewResult List(string category, int productPage = 1)
        {
            return View(new StudentsListViewModel
            {
                Students = _repository.Students
                .Where(p => category == null || p.Group.Name == category)                
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

        public ViewResult Edit(int studentId)
        {
            return View(_repository.Students.FirstOrDefault(s => s.StudentId == studentId));
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveStudent(student);
                TempData["message"] = $"{student.FirstName} {student.LastName} has been saved";
                return RedirectToAction("List");
            }
            else
                return View(student);
        }

        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            Student deleteStudent = _repository.DeleteStudent(studentId);
            if (deleteStudent != null)
            {
                TempData["message"] = $"{deleteStudent.FirstName} {deleteStudent.LastName} was deleted";
            }
            return RedirectToAction("List");
        }
    }
}
