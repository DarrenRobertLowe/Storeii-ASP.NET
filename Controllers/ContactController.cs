using Microsoft.AspNetCore.Mvc;

namespace Storeii.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}