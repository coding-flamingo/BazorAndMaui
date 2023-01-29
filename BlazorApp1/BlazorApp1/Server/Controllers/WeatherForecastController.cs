using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return GetWeatherForecasts(5);
        }


        /// <summary>
        /// Returns Random weather data
        /// </summary>
        /// <param name="count">Number of days you want to generate </param>
        /// <returns> Array of <see cref="WeatherForecast"/></returns>
        /// <exception cref="HttpRequestException">Error contacting server</exception>
        private IEnumerable<WeatherForecast> GetWeatherForecasts(int count)
        {
            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {

                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}