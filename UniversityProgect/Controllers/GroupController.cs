using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.DataModel;
using UniversityProgect.Interfaces;
using UniversityProgect.Models.ViewModels;

namespace UniversityProgect.Controllers
{
    public class GroupController : Controller
    {
        private IGroupRepository _repository;

        private IStudentRepository _studentRepository;

        public GroupController(IGroupRepository repository, IStudentRepository studentRepository)
        {
            _repository = repository;
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public ViewResult List(int courseId)
        {
            return View(new GroupListViewModel
            {
                Groups = _repository.Groups.Where(g => g.CourseId == courseId)
            });
        }

        public ViewResult List()
        {
            return View(new GroupListViewModel
            {
                Groups = _repository.Groups
                .OrderBy(o => o.GroupId)
            });
        }

        public ViewResult Edit(int groupId)
        {
            return View(_repository.Groups.FirstOrDefault(g => g.GroupId == groupId));
        }

        [HttpPost]
        public IActionResult Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveGroup(group);
                TempData["message"] = $"{group.Name} has been saved";
                return RedirectToAction("List");
            }
            else
                return View(group);
        }

        [HttpPost]
        public IActionResult DeleteGroup(int groupId)
        {
            if(_studentRepository.Students.FirstOrDefault(s => s.GroupId ==groupId) != null)
            {
                TempData["message"] = $"This group cannot be deleted";
                return RedirectToAction("List");
            }
            
            Group deleteGroup = _repository.DeleteGroup(groupId);
            if (deleteGroup != null)
            {
                TempData["message"] = $"{deleteGroup.Name} has deleted";
            }
            return RedirectToAction("List");
        }
    }
}
