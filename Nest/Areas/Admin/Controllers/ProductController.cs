using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Nest.DAL;
using Nest.Models;

namespace Pustok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.Products.Include(c => c.Categories).ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = _dbContext.Products.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            return View(); 
        }
        public IActionResult Update(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var product = _dbContext.Products.FirstOrDefault(c=>c.Id==id);
            if (product ==null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(newProduct);
            }
            var oldProduct = _dbContext.Products.FirstOrDefault(c => c.Id == newProduct.Id);
            if (newProduct == null)
            {
                return NotFound();
            }

            oldProduct.Name = newProduct.Name;
            oldProduct.Description = newProduct.Description;
            oldProduct.InStock = newProduct.InStock;
            oldProduct.Price = newProduct.Price;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
