using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLibrary.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core_Project.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            var value = portfolioManager.TGetList();
            return View(value);
        }


        // Portfolio Ekleme işlemleri
        [HttpGet]
        public IActionResult AddPortfolio() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio p)
        {      
            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                portfolioManager.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeletePortoflio(int id)
        {
            var value = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = portfolioManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {

            portfolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }
    }
}
