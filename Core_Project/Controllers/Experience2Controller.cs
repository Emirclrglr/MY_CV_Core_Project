using BusinessLayer.Concrete;
using DataAccessLibrary.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Project.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetByID(int ExpID)
        {
            var findid = experienceManager.TGetByID(ExpID);
            var values = JsonConvert.SerializeObject(findid);
            return Json(values);
            
        }

        public IActionResult DeleteExperience(int id)
        {
            var findid = experienceManager.TGetByID(id);
            experienceManager.TDelete(findid);
            return NoContent();
        }
    }
}
