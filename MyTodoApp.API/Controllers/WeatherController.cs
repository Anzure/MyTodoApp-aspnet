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
    public IEnumerable<WeatherForecast> GetForecast()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    
    [HttpGet("helloworld")]
    public String GetHelloWorld()
    {
        return "Hello World";
    }
    
    [HttpGet("ping")]
    public String getPingPong()
    {
        return "pong";
    }
    
}