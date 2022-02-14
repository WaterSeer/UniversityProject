using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Models.ViewModels;
using UniversityProject.Services.Infrastructure.Dtos;
using UniversityProject.Services.Infrastructure.Interfaces;

namespace UniversityProgect.Controllers
{
    public class GroupController : Controller
    {
        private IGroupService _groupService;

        private IStudentService _studentService;

        public GroupController(IGroupService groupService, IStudentService studentService)
        {
            _groupService = groupService;
            _studentService = studentService;
        }

        [HttpPost]
        public ViewResult List(int courseId)
        {
            return View(new GroupListViewModel
            {
                Groups = _groupService.GetGroups().Where(g => g.CourseId == courseId)
            });
        }

        public ViewResult List()
        {
            return View(new GroupListViewModel
            {
                Groups = _groupService.GetGroups()
                .OrderBy(o => o.GroupId)
            });
        }

        public ViewResult Edit(int groupId)
        {
            return View(_groupService.GetGroups().FirstOrDefault(g => g.GroupId == groupId));
        }

        [HttpPost]
        public IActionResult Edit(GroupDto group)
        {
            if (ModelState.IsValid)
            {
                _groupService.UpdateGroup(group);
                TempData["message"] = $"{group.Name} has been saved";
                return RedirectToAction("List");
            }
            else
                return View(group);
        }

        [HttpPost]
        public IActionResult DeleteGroup(int groupId)
        {
            if (_studentService.GetStudents().FirstOrDefault(s => s.GroupId == groupId) != null)
            {
                TempData["message"] = $"This group cannot be deleted";
                return RedirectToAction("List");
            }

            GroupDto deleteGroup = _groupService.DeleteGroup(groupId);
            if (deleteGroup != null)
            {
                TempData["message"] = $"{deleteGroup.Name} has deleted";
            }
            return RedirectToAction("List");
        }
    }
}
