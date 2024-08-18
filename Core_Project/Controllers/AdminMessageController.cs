using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLibrary.Concrete;
using DataAccessLibrary.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class AdminMessageController : Controller
    {

        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult RecievedMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.GetListReceiverMessages(p);
            return View(values);
        }

        public IActionResult SentMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.GetListSenderMessages(p);
            return View(values);
        }

        public IActionResult ReceivedMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        public IActionResult RecievedMessageDelete(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(values);
            return RedirectToAction("RecievedMessageList");
        }

        public IActionResult SentMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        public IActionResult SentMessageDelete(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(values);
            return RedirectToAction("SentMessageList");
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            Context c = new Context();
            var username = c.Users.Where(x=>x.Email == p.Receiver).Select(y=>y.FirstName + " " + y.LastName).FirstOrDefault();
            p.ReceiverName = username;
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writerMessageManager.TAdd(p);
            return RedirectToAction("SentMessageList");
        }
    }
}
