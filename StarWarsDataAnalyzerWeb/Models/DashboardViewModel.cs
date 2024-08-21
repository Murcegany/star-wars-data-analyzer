namespace StarWarsDataAnalyzerWeb.ViewModels
{
    public class DashboardViewModel
    {
        public List<string> PlanetNames { get; set; }
        public List<int> PlanetPopulations { get; set; }
        public Dictionary<string, int> Climates { get; set; }
        public Dictionary<string, int> Terrains { get; set; }
        public List<string> Top5Planets { get; set; }
        public List<int> Top5Populations { get; set; }
        public List<(string Climate, double AveragePopulation)> AveragePopulationByClimate { get; set; }
        public List<(string Terrain, double AveragePopulation)> AveragePopulationByTerrain { get; set; }
    }
}
