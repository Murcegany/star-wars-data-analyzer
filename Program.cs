using System;
using System.Threading.Tasks;
using StarWarsDataAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        var swapiService = new SwapiService();

        var planetResponse = await swapiService.GetDataAsync<SwapiService.PlanetResponse>("planets");
        foreach (var planet in planetResponse.Results)
        {
            Console.WriteLine($"Name: {planet.Name}, Climate: {planet.Climate}");
        }
    }
}
