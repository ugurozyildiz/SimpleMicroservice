using Microsoft.AspNetCore.Mvc;

namespace SimpleMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return WeatherForecastData.Summaries.ToArray();

        }

        [HttpPost(Name = "PostWeatherForecast")]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {
            if (forecast == null)
            {
                return BadRequest("Invalid forecast data.");
            }

            WeatherForecastData.Summaries.Add(forecast);
            return CreatedAtAction(nameof(Get), new { forecast.Date }, forecast);
        }

        [HttpPut("{Summary}", Name = "UpdateWeatherForecast")]
        public IActionResult Update(string Summary, [FromBody] WeatherForecast updatedForecast)
        {
            var existingForecast = WeatherForecastData.Summaries.FirstOrDefault(f => f.Summary == Summary);
            if (existingForecast == null)
            {
                return NotFound($"No forecast found for Summary {Summary}.");
            }

            existingForecast.TemperatureC = updatedForecast.TemperatureC;
            existingForecast.Summary = updatedForecast.Summary;
            return NoContent();
        }

        [HttpDelete("{Summary}", Name = "DeleteWeatherForecast")]
        public IActionResult Delete(string Summary)
        {
            var forecast = WeatherForecastData.Summaries.FirstOrDefault(f => f.Summary == Summary);
            if (forecast == null)
            {
                return NotFound($"No forecast found for Summary {Summary}.");
            }

            WeatherForecastData.Summaries.Remove(forecast);
            return NoContent();
        }
    }
}