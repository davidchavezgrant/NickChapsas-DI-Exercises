namespace CustomCommandHandler.Time;

internal interface IDateTimeProvider
{
	DateTime DateTimeNow    { get; }
	DateTime DateTimeUtcNow { get; }
}


internal sealed class DateTimeProvider : IDateTimeProvider
{
	public DateTime DateTimeNow    => DateTime.Now;
	public DateTime DateTimeUtcNow => DateTime.UtcNow;
}