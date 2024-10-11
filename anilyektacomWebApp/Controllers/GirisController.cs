using anilyektacomWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data;

namespace anilyektacomWebApp.Controllers
{
    public class GirisController : Controller
    {

        private readonly ILogger<GirisController> _logger;
        private readonly icSQL _sqlHelper;

        public GirisController(ILogger<GirisController> logger)
        {
            _logger = logger;
            _sqlHelper = new icSQL();  
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
         
        [HttpPost]
        public IActionResult Index(string password)
        {
            int result = _sqlHelper.ExecuteScalarQuery(password, true);
            if (result == 1)
            {
                HttpContext.Session.SetString("pin", "1997");
                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
                HttpContext.Session.SetString("pin", "yanlis");
                return RedirectToAction("Index", "Giris");
            }
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

        public ActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Giris");
        }
    }
}
