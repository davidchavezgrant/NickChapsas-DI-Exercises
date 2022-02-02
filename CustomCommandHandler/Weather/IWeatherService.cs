namespace CustomCommandHandler.Weather;

internal interface IWeatherService
{
	Task GetCurrentWeatherAsync(string location);

}


internal sealed class OpenWeatherService : IWeatherService
{
	public Task GetCurrentWeatherAsync(string location) => null;
}