using Microsoft.AspNetCore.Mvc;

namespace weatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "QUENTE PRA CARALHO",
            "QUENTE PRA CARALHO",
            "QUENTE PRA CARALHO",
            "QUENTE PRA CARALHO",
            "QUENTE PRA CARALHO",
            "QUENTE PRA CARALHO",
            "QUENTE PRA CARALHO",
            "QUENTE PRA CARALHO",
            "QUENTE PRA CARALHO",
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(40, 50),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}