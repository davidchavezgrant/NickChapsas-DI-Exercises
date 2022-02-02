using CustomCommandHandler.Console;
using CustomCommandHandler.Weather;

namespace CustomCommandHandler.Handlers;

internal sealed class GetCurrentWeatherHandler : IHandler
{
	private readonly IConsoleWriter  _consoleWriter;
	private readonly IWeatherService _weatherService;
	public GetCurrentWeatherHandler(IConsoleWriter consoleWriter, IWeatherService weatherService)
	{
		this._consoleWriter  = consoleWriter;
		this._weatherService = weatherService;
	}

	public async Task HandleAsync()
	{
		var weather = this._weatherService.GetCurrentWeatherAsync("London");
		this._consoleWriter.WriteLine($"The temperature in London is {weather}");
	}
}