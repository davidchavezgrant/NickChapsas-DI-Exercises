namespace SmartUsingsTest;

public interface IConsoleWriter<T>
{
	void WriteLine(string message);
}

internal sealed class ConsoleWriter<T> : IConsoleWriter<T>
{
	public void WriteLine(string message)
	{
		System.Console.WriteLine(message);
	}
}