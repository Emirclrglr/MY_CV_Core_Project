using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLibrary.Concrete;
using DataAccessLibrary.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            var values = messageManager.TGetList().OrderByDescending(x=>x.Date).Take(5).ToList();
            return View(values);
        }
    }
}
