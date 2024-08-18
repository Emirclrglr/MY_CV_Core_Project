using Core_Project_Api.DAL.ApiContext;
using Core_Project_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var findid = c.Categories.Find(id);
            if (findid == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(findid);
                c.SaveChanges();
                return NoContent();
            }

        }

        [HttpPut]
        public IActionResult CategoryUpdate(Category p)
        {
            using var c = new Context();
            var findid = c.Find<Category>(p.CategoryID);
            if (findid == null)
            {
                return NotFound();
            }
            else
            {
                findid.CategoryName = p.CategoryName;
                c.Update(findid);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
