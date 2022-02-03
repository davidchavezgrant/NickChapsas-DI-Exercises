using CustomCommandHandler.Console;
using CustomCommandHandler.Time;

namespace CustomCommandHandler.Handlers;

[CommandName("time")]
internal sealed class GetCurrentTimeHandler : IHandler
{
	private readonly IConsoleWriter    _consoleWriter;
	private readonly IDateTimeProvider _dateTimeProvider;
	public GetCurrentTimeHandler(IConsoleWriter consoleWriter, IDateTimeProvider dateTimeProvider)
	{
		this._consoleWriter    = consoleWriter;
		this._dateTimeProvider = dateTimeProvider;
	}

	public Task HandleAsync()
	{
		var timeNow = this._dateTimeProvider.DateTimeNow;
		this._consoleWriter.WriteLine($"The current time is {timeNow}");
		return Task.CompletedTask;
	}

}