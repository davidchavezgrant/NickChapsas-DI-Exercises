namespace CustomCommandHandlerFromMemory.Time;


public interface ITimeService
{
	DateTime CurrentTime { get; }
}

internal sealed class TimeService : ITimeService
{
	public DateTime CurrentTime => DateTime.Now;
}