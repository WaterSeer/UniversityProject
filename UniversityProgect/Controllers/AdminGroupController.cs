using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityProgect.Interfaces;

namespace UniversityProgect.Controllers
{
    public class AdminGroupController : Controller
    {
        private IGroupRepository _repository;

        public AdminGroupController(IGroupRepository  repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Edit(int groupId)
        {
            return View(_repository.Groups.FirstOrDefault(p => p.GroupId == groupId));
        }
    }
}
