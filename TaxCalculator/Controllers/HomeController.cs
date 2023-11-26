using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiSettings _apiSettings;

        public HomeController(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings ?? throw new ArgumentNullException(nameof(apiSettings));
        }

        public IActionResult Index()
        {
            ViewBag.ApiUrl = _apiSettings.ApiUrl;

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
