using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class AdminNotificationList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
