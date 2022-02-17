using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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
                Groups = _groupService.GetGroups().Data.Where(g => g.CourseId == courseId)
            });
        }

        public ViewResult List()
        {
            return View(new GroupListViewModel
            {
                Groups = _groupService.GetGroups().Data
                .OrderBy(o => o.GroupId)
            });
        }

        public ViewResult Edit(int groupId)
        {
            return View(_groupService.GetGroups().Data.FirstOrDefault(g => g.GroupId == groupId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GroupDto group)
        {
            if (ModelState.IsValid)
            {
                await _groupService.UpdateGroupAsync(group);
                TempData["message"] = $"{group.Name} has been saved";
                return RedirectToAction("List");
            }
            else
                return View(group);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            if (_studentService.GetStudents().Data.FirstOrDefault(s => s.GroupId == groupId) != null)
            {
                TempData["message"] = $"This group cannot be deleted";
                return RedirectToAction("List");
            }

            var deleteGroup = await _groupService.DeleteGroupAsync(groupId);
            if (deleteGroup != null)
            {
                TempData["message"] = $"{deleteGroup.Data.Name} has deleted";
            }
            return RedirectToAction("List");
        }
    }
}
