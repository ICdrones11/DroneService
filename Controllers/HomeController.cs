using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DroneService.Models;

namespace DroneService.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index() {
            return View();

        }

    }
}
