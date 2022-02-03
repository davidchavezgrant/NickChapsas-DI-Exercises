namespace CustomCommandHandlerFromMemory;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class CommandNameAttribute : Attribute
{
	public           string CommandName { get; }

	public CommandNameAttribute(string name)
	{
		this.CommandName = name;
	}
}