using BusinessLayer.Concrete;
using DataAccessLibrary.Concrete;
using DataAccessLibrary.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ContactSubplaceController : Controller
    {

        ContactManager contactManager = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            using var c = new Context();
            var selectid = c.Contacts.Select(x => x.ContactID).FirstOrDefault();
            var values = contactManager.TGetByID(selectid);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            contactManager.TUpdate(p);
            return RedirectToAction("Index", "Default");
        }

    }

}

