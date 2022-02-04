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

        public GroupController(IGroupRepository repository)
        {
            _repository = repository;
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
    }
}
