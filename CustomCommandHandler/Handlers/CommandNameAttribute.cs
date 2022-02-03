namespace CustomCommandHandler.Handlers;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class CommandNameAttribute : Attribute
{
	public CommandNameAttribute(string commandName)
	{
		this.CommandName = commandName;
	}
	public string CommandName { get; }
}