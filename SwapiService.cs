using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;  // Add this line

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
            var response = await _httpClient.GetStringAsync($"https://swapi.dev/api/{endpoint}");
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
    }
}
