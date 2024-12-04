using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest.DAL;

namespace WaveCafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }




    }
}
