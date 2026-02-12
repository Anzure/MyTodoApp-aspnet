using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace MyTodoApp.API.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Kaldt", "Varmt", "Kjølig", "Mildt", "Hetebølge"
    ];

    [HttpGet("forecast")]
    public ActionResult<IEnumerable<WeatherForecast>> GetForecast()
    {
        var forecast = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        return Ok(forecast);
    }
    
    [HttpGet("hello")]
    public ActionResult<String> GetHelloWorld()
    {
        return Ok("Hello World!");
    }
    
    [HttpGet("ping")]
    public JsonResult getPingPong()
    {
        return new JsonResult(new { ping = "pong" });
    }
    
}