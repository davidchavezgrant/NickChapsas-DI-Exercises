using CustomCommandHandler.Console;

namespace CustomCommandHandler;

public sealed class Application
{
	private readonly IConsoleWriter _consoleWriter;
	public Application(IConsoleWriter consoleWriter)
	{
		this._consoleWriter = consoleWriter;
	}

	public async Task RunAsync(string[] args)
	{
		var command = args[0];
	}
}