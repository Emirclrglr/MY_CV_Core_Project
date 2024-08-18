using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class VisitedCountries:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
