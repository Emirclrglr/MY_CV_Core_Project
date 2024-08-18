using BusinessLayer.Concrete;
using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.ViewComponents.ProfilePic
{
    public class ProfilePictureList:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfilePictureList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.ImageUrl;
            return View(values);
        }
    }
}
