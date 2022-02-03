using Microsoft.Extensions.Logging;

namespace SmartUsingsTest;

public interface ILoggerAdapter<T>
{
	public void Log(LogLevel          level,    string          message, params object[] args);
	IDisposable TimedOperation(string template, params object[] args);
}
internal sealed class LoggerAdapter<T> : ILoggerAdapter<T>
{
	private readonly IConsoleWriter<LoggerAdapter<T>> _logger;
	public LoggerAdapter(IConsoleWriter<LoggerAdapter<T>> logger)
	{
		this._logger = logger;
	}

	public void Log(LogLevel level, string message, params object[] args)
	{
		_logger.WriteLine(message);
	}

	public IDisposable TimedOperation(string template, params object[] args)
	{
		return new TimedLogOperation<T>(this,
										LogLevel.Information,
										template,
										args);
	}
}