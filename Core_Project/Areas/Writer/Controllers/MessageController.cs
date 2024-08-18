using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLibrary.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        private readonly UserManager<WriterUser> _writerMessage;

        public MessageController(UserManager<WriterUser> writerMessage)
        {
            _writerMessage = writerMessage;
        }

        [Route("")]
        [Route("ReceiverMessage")]

        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _writerMessage.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListReceiverMessages(p);
            return View(messageList);
        }

        [Route("")]
        [Route("SenderMessage")]

        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _writerMessage.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListSenderMessages(p);
            return View(messageList);
        }
        [HttpGet]

        [Route("ReceivedMessageDetails/{id}")]
        public IActionResult ReceivedMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }
        [HttpGet]
        [Route("SentMessageDetails/{id}")]
        public IActionResult SentMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _writerMessage.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.FirstName + " " + values.LastName;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage");
        }

    }
}
