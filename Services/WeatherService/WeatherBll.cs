using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.External.WeatherApiWebService;
using Services.RequestContextAccessorService;
using Services.ResponseService;


namespace Services.WeatherService;

/// <summary>
/// The main purpose of this partial main file, is to give a clear overview of all dependencies related to this business logic layer,
/// furthermore the business logic layer acts like a higher orchestrations layer between the services, with this layer we avoid circular dependencies between each services
/// this gives us more flexibility to add and remove services without breaking affecting existing code.
/// </summary>
public partial class WeatherBll : ControllerBase, IWeatherBll
{
    private readonly IWeatherApiWebService _weatherApiWebService;
    private readonly IWeatherService _weatherService;
    private readonly IResponseService _responseService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRequestContextAccessorService _requestContextAccessorService;

    public WeatherBll(
        IWeatherApiWebService weatherApiWebService,
        IWeatherService weatherService,
        IResponseService responseService,
        IHttpContextAccessor httpContextAccessor,
        IRequestContextAccessorService requestContextAccessorService
    )
    {
        _weatherApiWebService = weatherApiWebService;
        _weatherService = weatherService;
        _responseService = responseService;
        _httpContextAccessor = httpContextAccessor;
        _requestContextAccessorService = requestContextAccessorService;
    }
}