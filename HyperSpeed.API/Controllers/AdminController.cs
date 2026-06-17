using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
