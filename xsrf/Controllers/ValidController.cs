using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace xsrf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ValidController> _logger;

        public ValidController(ILogger<ValidController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
