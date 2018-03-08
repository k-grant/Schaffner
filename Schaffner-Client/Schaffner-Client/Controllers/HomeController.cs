using Microsoft.AspNetCore.Mvc;

namespace Schaffner_Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
