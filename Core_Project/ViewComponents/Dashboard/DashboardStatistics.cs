using DataAccessLibrary.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class DashboardStatistics:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Portfolios.Count();
            ViewBag.v2 = context.Services.Count();
            ViewBag.v3 = context.Skills.Count();
            return View();
        }
    }
}
