using Microsoft.AspNetCore.Mvc;

namespace HyperSpeed.UI.Controllers
{
    public class LojaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
