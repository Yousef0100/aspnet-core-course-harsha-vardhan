using Microsoft.AspNetCore.Mvc;
using S8_RazorViews.Models;

namespace S8_RazorViews.Controllers;

public class WeatherController : Controller
{
    private readonly List<CityWeather> _weatherList = new List<CityWeather> { 
        new CityWeather("LDN", "London", Convert.ToDateTime("2030-01-01 8:00"), 33),
        new CityWeather("NYC", "New York", Convert.ToDateTime("2030-01-01 3:00"), 60),
        new CityWeather("PAR", "Paris", Convert.ToDateTime("2030-01-01 9:00"), 82),
        new CityWeather("CAI", "Cairo", Convert.ToDateTime("2030-01-01 2:00"), 85),
        new CityWeather("SSH", "Sharm", Convert.ToDateTime("2030-01-01 2:00"), 84),
        new CityWeather("DMT", "Damietta", Convert.ToDateTime("2030-01-01 12:00"), 77)
    };


    [HttpGet("/")]
    public IActionResult Index()
    {
        // preparing the view model to pass data to the view

        return View(_weatherList);
    }


    [HttpGet("weather/{cityCode:alpha}")]
    public IActionResult Details(string cityCode)
    {
        // fetching the details of the city weather where the city code is 'cityCode'
        CityWeather? cityWeather = _weatherList.Where(tmp => tmp.CityUniqueCode.Equals(cityCode)).FirstOrDefault();

        return View(cityWeather);
    }
}
