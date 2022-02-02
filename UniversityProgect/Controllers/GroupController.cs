using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        public ViewResult List()
        {
            return View(new GroupListViewModel
            {
                Groups = _repository.Groups
                .OrderBy(o => o.GroupId)
            });
        }

        public IActionResult Index1()
        {
            return View();
        }
    }
}
