using Microsoft.AspNetCore.Mvc;

namespace AnaokuluKatmanli.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
