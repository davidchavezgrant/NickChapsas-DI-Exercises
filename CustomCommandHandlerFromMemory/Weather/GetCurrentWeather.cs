using CustomCommandHandlerFromMemory.Console;

namespace CustomCommandHandlerFromMemory.Weather;

[CommandName("weather")]
internal sealed class GetCurrentWeather : IHandler
{
	private readonly IConsoleWriter _consoleWriter;
	public GetCurrentWeather(IConsoleWriter consoleWriter)
	{
		this._consoleWriter = consoleWriter;
	}

	public void Handle()
	{
		this._consoleWriter.WriteLine("The weather is great today thanks!");
	}
}