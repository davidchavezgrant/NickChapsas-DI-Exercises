namespace ContainerFromMemory;


interface IConsoleWriter
{
	void WriteLine(string message);
}
internal sealed class ConsoleWriter : IConsoleWriter
{
	public void WriteLine(string message) => Console.WriteLine(message);
}