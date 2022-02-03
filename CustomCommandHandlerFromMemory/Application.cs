using CustomCommandHandlerFromMemory.Console;

namespace CustomCommandHandlerFromMemory;

internal sealed class Application
{
	private readonly Mediator       _mediator;
	private readonly IConsoleWriter _consoleWriter;

	public Application(Mediator mediator, IConsoleWriter consoleWriter)
	{
		this._mediator      = mediator;
		this._consoleWriter = consoleWriter;
	}

	public void Run(string[] args)
	{
		if (args.Length == 0)
		{
			args = new[]
			{
				"weather"
			};
		}

		var command = args[0];

		var handler = _mediator.GetHandler(command);

		if (handler is null)
		{
			this._consoleWriter.WriteLine($"No handler was found for command named: {command}");
			return;
		}

		handler.Handle();
	}
}