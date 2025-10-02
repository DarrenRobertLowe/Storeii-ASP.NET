using Microsoft.AspNetCore.Mvc;
using Storeii.Data;
using Storeii.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Storeii.Controllers
{
    public class CartController : Controller
    {
        // get the context
        private readonly StoreiiContext _context;

        public CartController(StoreiiContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var cartIds = HttpContext.Session.GetObject<List<int>>("Cart") ?? new List<int>();

            var products = _context.Product
                .Where(p => cartIds.Contains(p.Id))
                .ToList();

            return View(products); // This becomes your Razor Model
        }


        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            // Optional: validate product exists
            var product = _context.Product.Find(id);
            if (product == null) return NotFound();

            // Retrieve cart from session or create new
            var cart = HttpContext.Session.GetObject<List<int>>("Cart") ?? new List<int>();

            // Add product ID to cart
            cart.Add(id);

            // Save updated cart back to session
            HttpContext.Session.SetObject("Cart", cart);

            // Redirect to product index or details
            return RedirectToAction("Index", "Product");
        }
    }
}
