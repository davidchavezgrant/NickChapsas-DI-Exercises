using CustomCommandHandlerFromMemory.Console;

namespace CustomCommandHandlerFromMemory.Weather;

[CommandName("weather")]
internal sealed class GetCurrentWeather : IHandler
{
	private readonly IConsoleWriter  _consoleWriter;
	private readonly IWeatherService _weatherService;

	public GetCurrentWeather(IConsoleWriter consoleWriter, IWeatherService weatherService)
	{
		this._consoleWriter  = consoleWriter;
		this._weatherService = weatherService;
	}

	public void Handle()
	{
		var weather = this._weatherService.GetWeather("Boston");
		this._consoleWriter.WriteLine(weather);
	}
}