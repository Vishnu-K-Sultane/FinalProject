using Microsoft.AspNetCore.Mvc;

namespace FinalProject.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
