using Microsoft.AspNetCore.Mvc;
using json_return_lab_practice.Data;
using Microsoft.EntityFrameworkCore;
using json_return_lab_practice.Models;

namespace json_return_lab_practice.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            if (!await _context.Products.AnyAsync())
            {
                var dummyProducts = new List<ProductClass>
                {
                    new ProductClass { Name = "Laptop", Price = 999.99m },
                    new ProductClass { Name = "Smartphone", Price = 499.99m },
                    new ProductClass { Name = "Tablet", Price = 299.99m }
                };

                await _context.Products.AddRangeAsync(dummyProducts);
                await _context.SaveChangesAsync();
            }

            var products = await _context.Products.ToListAsync();
            return Json(products);
        }
    }
}
