using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;

namespace S12_DependencyInjection.Controllers;

public class WeatherController : Controller
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    [Route("~/weather")]
    public IActionResult Index()
    {
        IEnumerable<CityWeather> weatherList = _weatherService.GetCitiesWeather();

        return View(weatherList);
    }


    [Route("~/weather/{cityCode:alpha}")]
    public IActionResult Details(string cityCode)
    {
        // fetching the details of the city weather where the city code is 'cityCode'

        CityWeather? cityWeather = _weatherService.GetCityWeatherByCityCode(cityCode);

        return View(cityWeather);
    }
}
