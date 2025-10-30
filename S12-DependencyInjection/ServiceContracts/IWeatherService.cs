using Models;

namespace ServiceContracts;

public interface IWeatherService
{
    public IEnumerable<CityWeather> GetCitiesWeather();
    public CityWeather? GetCityWeatherByCityCode(string cityCode);
}
