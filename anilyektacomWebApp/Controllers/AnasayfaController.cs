using anilyektacomWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace anilyektacomWebApp.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly ILogger<AnasayfaController> _logger;

        public AnasayfaController(ILogger<AnasayfaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("pin")) || HttpContext.Session.GetString("pin") != "1997")
            {
                return RedirectToAction("Index", "Giris");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
