using manageExceptions.CustomGlobalResponse;
using manageExceptions.GlobalExceptions;
using Microsoft.AspNetCore.Mvc;

namespace manageExceptions.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private List<WeatherForecast> _forecasts;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
    }

    [HttpGet]
    [Route("/api/weather")]
    public IActionResult GetAll()
    {
        return Ok(_forecasts);
    }

    [HttpGet]
    [Route("/api/weather/{index}")]
    public IActionResult Get(int index)
    {
        try
        {
            var forecast = _forecasts[index];
            return Ok(forecast);
        }
        catch (Exception ex)
        {
            return BadRequest("Error occurred.");
        }
    }
}

[ApiController]
[Route("[controller]")]
public class WeatherForecast2Controller : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private List<WeatherForecast> _forecasts;

    public WeatherForecast2Controller(
        ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
    }

    [HttpGet]
    [Route("/api/weather2")]
    public IActionResult GetAll()
    {
        return Ok(_forecasts);
    }

    [HttpGet]
    [Route("/api/weather2/{index}")]
    public IActionResult Get(int index)
    {
        try
        {
            if (index == 6)
                throw new CustomException("The index is equals to 6.");
            var forecast = _forecasts[index];
            return Ok(forecast);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest("A Generic Error Occurred.");
        }
    }
}

[ApiController]
[Route("[controller]")]
public class WeatherForecast3Controller : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private List<WeatherForecast> _forecasts;

    public WeatherForecast3Controller(
        ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
    }

    [HttpGet]
    [Route("/api/weather3")]
    public IActionResult GetAll()
    {
        return Ok(_forecasts);
    }

    [HttpGet]
    [Route("/api/weather3/{index}")]
    public IActionResult Get(int index)
    {
        if (index == 6)
            throw new CustomException("The index is equals to 6.");
        var forecast = _forecasts[index];
        return Ok(forecast);
    }
}

[ApiController]
[Route("[controller]")]
public class WeatherForecast4Controller : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private List<WeatherForecast> _forecasts;

    public WeatherForecast4Controller(
        ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
    }

    [HttpGet]
    [Route("/api/weather4")]
    public IActionResult GetAll()
    {
        return Ok(CustomResponse<List<WeatherForecast>>.Create(_forecasts));
    }

    [HttpGet]
    [Route("/api/weather4/{index}")]
    public IActionResult Get(int index)
    {
        if (index == 6)
            throw new CustomException("The index is equals to 6.");
        var forecast = _forecasts[index];
        return Ok(CustomResponse<WeatherForecast>.Create(forecast));
    }
}