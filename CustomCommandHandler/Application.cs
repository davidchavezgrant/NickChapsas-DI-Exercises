using CustomCommandHandler.Console;
using CustomCommandHandler.Handlers;

namespace CustomCommandHandler;

public sealed class Application
{
	private readonly IConsoleWriter      _consoleWriter;
	private readonly HandlerOrchestrator _orchestrator;
	public Application(IConsoleWriter consoleWriter, HandlerOrchestrator orchestrator)
	{
		this._consoleWriter = consoleWriter;
		this._orchestrator  = orchestrator;
	}

	public async Task RunAsync(string[] args)
	{
		var command = args[0];

		var handler = this._orchestrator.GetHandlerForCommandName(command);

		if (handler is null)
		{
			this._consoleWriter.WriteLine($"No handler found for command name {command}");
			return;
		}

		await handler.HandleAsync();
	}
}