namespace SimpleMicroservice
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public static class WeatherForecastData
    {
        public static List<WeatherForecast> Summaries { get; } = new()
        {
            new(){Date = DateOnly.FromDateTime(DateTime.Now),Summary = "Freezing",TemperatureC = 15},
            new(){Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),Summary = "Bracing",TemperatureC = 25},
            new(){Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),Summary = "Chilly",TemperatureC = 30},
            new(){Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),Summary = "Cool",TemperatureC = 35},
            new(){Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),Summary = "Mild",TemperatureC = 40},
            new(){Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),Summary = "Warm",TemperatureC = 45},
        };
    }
}
