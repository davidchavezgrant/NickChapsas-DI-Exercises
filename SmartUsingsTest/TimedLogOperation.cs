using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace SmartUsingsTest;

internal sealed class TimedLogOperation<T> : IDisposable
{
	private readonly ILoggerAdapter<T> _logger;
	private readonly string            _message;
	private readonly LogLevel          _logLevel;
	private readonly object?[]         _args;
	private readonly Stopwatch         _stopwatch;
	public TimedLogOperation(ILoggerAdapter<T> logger, LogLevel logLevel, string message,
							 object?[]         args)
	{
		this._logLevel  = logLevel;
		this._message   = message;
		this._logger    = logger;
		this._args      = args;
		this._stopwatch = Stopwatch.StartNew();
	}

	public void Dispose()
	{
		Thread.Sleep(1000);
		this._stopwatch.Stop();
		_logger.Log(this._logLevel, $"{_message}: Operation took {this._stopwatch.ElapsedMilliseconds} milliseconds");
	}
}