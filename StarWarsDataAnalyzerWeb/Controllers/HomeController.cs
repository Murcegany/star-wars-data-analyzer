using Microsoft.AspNetCore.Mvc;
using StarWarsDataAnalyzerWeb.Models;
using StarWarsDataAnalyzerWeb.Services;
using System.Threading.Tasks;

namespace StarWarsDataAnalyzerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SwapiService _swapiService;

        public HomeController(ILogger<HomeController> logger, SwapiService swapiService)
        {
            _logger = logger;
            _swapiService = swapiService;
        }

        public async Task<IActionResult> Index()
        {
            var planetResponse = await _swapiService.GetDataAsync<SwapiService.PlanetResponse>("planets");
            return View(planetResponse.Results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
