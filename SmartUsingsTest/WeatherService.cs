namespace SmartUsingsTest;

public interface IWeatherService
{
	string GetCurrentWeather(string city);
}

internal sealed class WeatherService : IWeatherService
{
	public string GetCurrentWeather(string city) => $"Good weather in {city}";
}


internal sealed class LoggedWeatherService : IWeatherService
{
	private readonly IWeatherService                 _weatherService;
	private readonly ILoggerAdapter<IWeatherService> _logger;
	public LoggedWeatherService(IWeatherService weatherService, ILoggerAdapter<IWeatherService> logger)
	{
		this._weatherService = weatherService;
		this._logger         = logger;
	}

	public string GetCurrentWeather(string city)
	{
		using var _ = this._logger.TimedOperation($"Weather retrieval for city {city}");
		return this._weatherService.GetCurrentWeather("Boston");

	}
}