﻿using WeatherApp.Models;

namespace ServiceContracts
{
    public interface IWeatherService 
    {
        List<CityWeather> GetWeatherDetails();

        CityWeather? GetWeatherByCityCode(string cityCode);
    }
}