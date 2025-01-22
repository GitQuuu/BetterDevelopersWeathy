using Microsoft.AspNetCore.Mvc;
using Services.External.WeatherApiWebService;
using Services.WeatherApiWebService.WeatherService;

namespace Services.WeatherService;

public partial class WeatherBll : ControllerBase,  IWeatherBll
{
    private readonly IWeatherApiWebService _weatherApiWebService;
    private readonly IWeatherService _weatherService;

    public WeatherBll(
        IWeatherApiWebService weatherApiWebService,
        IWeatherService weatherService
        )
    {
        _weatherApiWebService = weatherApiWebService;
        _weatherService = weatherService;
    }
}