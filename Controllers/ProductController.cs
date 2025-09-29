using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Storeii.Data;
using Storeii.Services;
using System.Threading.Tasks;

namespace Storeii.Controllers
{
    //[Route("Products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }


        // GET: /Products/34
        public async Task<IActionResult> Details(int id, string? slug)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();

            // code to allow slugs in URLs and redirect when users visit an invalid slug
            // e.g. /products/34 or /products/34/red-shirt (wrong slug), we redirect them
            // to the correct URL: /products/34/red-t-shirt.
            var expectedSlug = product.ProductName.ToLower().Replace(" ", "-").Trim('-');
            if (slug != expectedSlug)
            {
                return RedirectToAction("Details", new {id, slug = expectedSlug});
            }

            return View(product);
        }
    }
}
