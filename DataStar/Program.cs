using System;
using System.Threading.Tasks;
using StarWarsDataAnalyzer;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var swapiService = new SwapiService();

            var planetResponse = await swapiService.GetDataAsync<SwapiService.PlanetResponse>("planets");

            if (planetResponse?.Results != null)
            {
                foreach (var planet in planetResponse.Results)
                {
                    Console.WriteLine($"Name: {planet.Name}");
                    Console.WriteLine($"Climate: {planet.Climate}");
                    Console.WriteLine($"Terrain: {planet.Terrain}");
                    Console.WriteLine($"Population: {planet.Population}");
                    Console.WriteLine(new string('-', 20));
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
