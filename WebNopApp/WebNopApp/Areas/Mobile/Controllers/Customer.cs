using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNopApp.Areas.Mobile.Controllers
{
    [Area("Mobile")]
    public class Customer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
