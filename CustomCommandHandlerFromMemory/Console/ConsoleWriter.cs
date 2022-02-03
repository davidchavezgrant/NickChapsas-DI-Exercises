namespace CustomCommandHandlerFromMemory.Console;

public interface IConsoleWriter
{
	void WriteLine(string message);
}
internal sealed class ConsoleWriter : IConsoleWriter
{
	public void WriteLine(string message)
	{
		System.Console.WriteLine(message);
	}
}