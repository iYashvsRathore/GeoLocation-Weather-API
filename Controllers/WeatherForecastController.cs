using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException();
            _logger = logger ?? throw new ArgumentNullException();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WeatherForecastDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<WeatherForecastDTO>> Get([FromQuery] RequestDTO request)
        {
            //request.StartDate = "2024-05-06";
            //request.EndDate = "2024-05-08";

            var response = await _weatherService.GetWeatherForecast(request).ConfigureAwait(false);

            if(response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response);
            }
        }
    }
}
