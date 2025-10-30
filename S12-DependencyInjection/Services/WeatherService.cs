using ServiceContracts;
using Models;

namespace Services;

public class WeatherService : IWeatherService
{
    private readonly List<CityWeather> _citiesWeather;

    public WeatherService()
    {
        _citiesWeather = new List<CityWeather>()
        {
            new CityWeather("NYC", "New York", DateTime.Now, 72),
            new CityWeather("LDN", "London", DateTime.Now, 68),
            new CityWeather("BLR", "Bangalore", DateTime.Now, 85),
            new CityWeather("PAR", "Paris", DateTime.Now, 82),
            new CityWeather("CAI", "Cairo", DateTime.Now, 85),
            new CityWeather("SSH", "Sharm", DateTime.Now, 84),
            new CityWeather("DMT", "Damietta", DateTime.Now, 77),

            new CityWeather("TKY", "Tokyo", DateTime.Now, 65),
            new CityWeather("SYD", "Sydney", DateTime.Now, 59),
            new CityWeather("MOS", "Moscow", DateTime.Now, 45),
            new CityWeather("RIO", "Rio de Janeiro", DateTime.Now, 90),
            new CityWeather("BER", "Berlin", DateTime.Now, 70),
            new CityWeather("DXB", "Dubai", DateTime.Now, 100),
            new CityWeather("IST", "Istanbul", DateTime.Now, 78),
            new CityWeather("TOR", "Toronto", DateTime.Now, 55),
            new CityWeather("ROM", "Rome", DateTime.Now, 80),
            new CityWeather("DEL", "Delhi", DateTime.Now, 95),
            new CityWeather("JED", "Jeddah", DateTime.Now, 98),
            new CityWeather("OSL", "Oslo", DateTime.Now, 50),
            new CityWeather("HEL", "Helsinki", DateTime.Now, 42),
            new CityWeather("ANC", "Anchorage", DateTime.Now, 15),
            new CityWeather("STO", "Stockholm", DateTime.Now, 48),
            new CityWeather("BJS", "Beijing", DateTime.Now, 88),
            new CityWeather("MEX", "Mexico City", DateTime.Now, 76),
            new CityWeather("LOS", "Lagos", DateTime.Now, 92)
        };
    }

    public IEnumerable<CityWeather> GetCitiesWeather()
    {
        return _citiesWeather;
    }

    public CityWeather? GetCityWeatherByCityCode(string cityCode)
    {
        return _citiesWeather.SingleOrDefault(city => city.CityUniqueCode.ToLower().Equals(cityCode.ToLower()));
    }
}
