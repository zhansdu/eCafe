using System.Collections.Generic;
using newProjectJs.Models;

namespace newProjectJs.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
