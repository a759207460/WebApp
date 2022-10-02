using Microsoft.AspNetCore.Mvc;

namespace WebNopApp.Area.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
