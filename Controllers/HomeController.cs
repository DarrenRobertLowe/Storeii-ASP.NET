using Microsoft.AspNetCore.Mvc;

namespace Storeii.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
