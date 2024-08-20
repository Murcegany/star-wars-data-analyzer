using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarWarsDataAnalyzer
{
    public class SwapiService
    {
        private readonly HttpClient _httpClient;

        public SwapiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetDataAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetStringAsync($"https://swapi.dev/api/{endpoint}/");
            return JsonConvert.DeserializeObject<T>(response);
        }

        public class Planet
        {
            public string Name { get; set; }
            public string Rotation_period { get; set; }
            public string Orbital_period { get; set; }
            public string Diameter { get; set; }
            public string Climate { get; set; }
            public string Gravity { get; set; }
            public string Terrain { get; set; }
            public string Population { get; set; }
        }

        public class PlanetResponse
        {
            public List<Planet> Results { get; set; }
        }


        public class Starship
        {
            public string Name { get; set; }
            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public string Cost_in_credits { get; set; }
            public string Length { get; set; }
            public string Max_atmosphering_speed { get; set; }
            public string Crew { get; set; }
            public string Passengers { get; set; }
            public string Cargo_capacity { get; set; }
            public string Consumables { get; set; }
            public string Hyperdrive_rating { get; set; }
            public string MGLT { get; set; }
            public string Starship_class { get; set; }
            public List<string> Pilots { get; set; }
            public List<string> Films { get; set; }
        }

        public class StarshipResponse
        {
            public List<Starship> Results { get; set; }
        }
    }
}
