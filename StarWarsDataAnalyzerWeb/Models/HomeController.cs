using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly SwapiService _swapiService;

    public HomeController(SwapiService swapiService)
    {
        _swapiService = swapiService;
    }

    public async Task<IActionResult> Index()
    {
        var planetResponse = await _swapiService.GetDataAsync<SwapiService.PlanetResponse>("planets");
        return View(planetResponse.Results);
    }
}
