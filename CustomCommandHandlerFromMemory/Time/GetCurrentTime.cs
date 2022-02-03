using CustomCommandHandlerFromMemory.Console;

namespace CustomCommandHandlerFromMemory.Time;

[CommandName("time")]
internal sealed class GetCurrentTime : IHandler
{
	private readonly IConsoleWriter _consoleWriter;
	private readonly ITimeService   _timeService;

	public GetCurrentTime(IConsoleWriter consoleWriter, ITimeService timeService)
	{
		this._consoleWriter = consoleWriter;
		this._timeService   = timeService;
	}
	public void Handle()
	{
		var time = this._timeService.CurrentTime;
		this._consoleWriter.WriteLine(time.ToString());
	}
}