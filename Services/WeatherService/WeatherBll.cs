using Microsoft.AspNetCore.Mvc;
using Services.External.WeatherApiWebService;
using Services.External.WeatherApiWebService.ResponseService;
using Services.WeatherApiWebService.WeatherService;

namespace Services.WeatherService;

public partial class WeatherBll : ControllerBase, IWeatherBll
{
    private readonly IWeatherApiWebService _weatherApiWebService;
    private readonly IWeatherService _weatherService;
    private readonly IResponseService _responseService;

    public WeatherBll(
        IWeatherApiWebService weatherApiWebService,
        IWeatherService weatherService,
        IResponseService responseService
    )
    {
        _weatherApiWebService = weatherApiWebService;
        _weatherService = weatherService;
        _responseService = responseService;
    }
}