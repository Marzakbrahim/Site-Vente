using Microsoft.AspNetCore.Mvc;
using MVCPanierManager.Models;
using System.Diagnostics;

namespace MVCPanierManager.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index()
        {
            return RedirectToAction("Index","Panier");
        }

        //[Route("Articles")]
        //public IActionResult Privacy()
        //{
        //    return RedirectToAction("Index","Article");
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
