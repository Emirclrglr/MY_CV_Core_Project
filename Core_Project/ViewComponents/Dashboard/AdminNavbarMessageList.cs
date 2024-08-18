using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLibrary.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Project.ViewComponents.Dashboard
{

    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            string p = "admin@gmail.com"; ;
            var values = writerMessageManager.GetListReceiverMessages(p).OrderByDescending(x => x.Id).Take(3).ToList();
            //var img1 = c.WriterMessages.Where(x=>x.Receiver == p).Select(y=>y.Sender).FirstOrDefault();
            //var img2 = c.Users.Where(x=>x.Email == img1).Select(y=>y.ImageUrl).FirstOrDefault();
            var img2 = c.Users.Where(x => x.Email != p).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.v = img2;
            return View(values);
        }
    }
}
