using BusinessLayer.Concrete;
using DataAccessLibrary.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());



        // Index sayfası
        public IActionResult Index()
        {
            var values = socialMediaManager.TGetList();
            return View(values);
        }

        // Silme işlemleri
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = socialMediaManager.TGetByID(id);
            socialMediaManager.TDelete(value);
            return RedirectToAction("Index");
        }

        // Ekleme işlemleri

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
        {
            p.Status = true;
            socialMediaManager.TAdd(p);
            return RedirectToAction("Index");
        }

        // Düzenleme işlemleri

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values = socialMediaManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia p)
        {
            socialMediaManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
