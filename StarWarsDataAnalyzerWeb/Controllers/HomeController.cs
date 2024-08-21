using Microsoft.AspNetCore.Mvc;
using StarWarsDataAnalyzerWeb.Models;
using StarWarsDataAnalyzerWeb.Services;
using StarWarsDataAnalyzerWeb.ViewModels;
using System.Linq;
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

            var planetViewModel = planetResponse.Results.Select(p => new PlanetViewModel
            {
                Name = p.Name,
                Climate = p.Climate,
                Terrain = p.Terrain,
                Population = int.TryParse(p.Population, out var population) ? population : 0
            }).ToList();

            // Prepare metrics for the dashboard
            var planetNames = planetViewModel.Select(p => p.Name).ToArray();
            var planetPopulations = planetViewModel.Select(p => p.Population).ToArray();
            var climates = planetViewModel.GroupBy(p => p.Climate).ToDictionary(g => g.Key, g => g.Count());
            var terrains = planetViewModel.GroupBy(p => p.Terrain).ToDictionary(g => g.Key, g => g.Count());

            var top5Planets = planetViewModel
                .Where(p => p.Population > 0)
                .OrderByDescending(p => p.Population)
                .Take(5)
                .Select(p => new { p.Name, p.Population });

            var averagePopulationByClimate = planetViewModel
                .GroupBy(p => p.Climate)
                .Select(g => new { Climate = g.Key, AveragePopulation = g.Average(p => p.Population) });

            var averagePopulationByTerrain = planetViewModel
                .GroupBy(p => p.Terrain)
                .Select(g => new { Terrain = g.Key, AveragePopulation = g.Average(p => p.Population) });

            ViewBag.PlanetNames = planetNames;
            ViewBag.PlanetPopulations = planetPopulations;
            ViewBag.Climates = climates;
            ViewBag.Terrains = terrains;
            ViewBag.Top5Planets = top5Planets;
            ViewBag.AveragePopulationByClimate = averagePopulationByClimate;
            ViewBag.AveragePopulationByTerrain = averagePopulationByTerrain;

            return View(planetViewModel); // Pass the model for both the table and the dashboard
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
