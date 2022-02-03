using CustomCommandHandlerFromMemory.Console;

namespace CustomCommandHandlerFromMemory.Time;

[CommandName("time")]
internal sealed class GetCurrentTime : IHandler
{
	private readonly IConsoleWriter _consoleWriter;

	public GetCurrentTime(IConsoleWriter consoleWriter)
	{
		this._consoleWriter = consoleWriter;
	}
	public void Handle()
	{
		this._consoleWriter.WriteLine(DateTime.Now.ToString());
	}
}