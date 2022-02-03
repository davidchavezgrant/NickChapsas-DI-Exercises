namespace SourceGeneratorTEst;

public interface IConsoleWriter
{
	void WriteLine(string message);
}
public class ConsoleWriter : IConsoleWriter
{
	public void WriteLine(string message) => System.Console.WriteLine(message);
}