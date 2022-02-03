namespace CustomCommandHandlerFromMemory.Weather;

public interface IWeatherService
{
	string GetWeather(string location);
}

internal sealed class WeatherService : IWeatherService
{
	public string GetWeather(string location) => $"weather is great in {location}";
}