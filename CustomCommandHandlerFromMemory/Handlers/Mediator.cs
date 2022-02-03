using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CustomCommandHandlerFromMemory;

internal sealed class Mediator
{
	private readonly IServiceScopeFactory         _serviceScopeFactory;
	private readonly Dictionary<string, TypeInfo> _handlerTypes = new();
	public Mediator(IServiceScopeFactory serviceScopeFactory)
	{
		this._serviceScopeFactory = serviceScopeFactory;
		RegisterCommandHandlers();
	}

	private void RegisterCommandHandlers()
	{
		var handlerTypes = HandlerExtensions.GetHandlerTypesForAssembly(typeof(IHandler).Assembly);

		foreach (var handlerType in handlerTypes)
		{
			var name = handlerType.GetCustomAttribute<CommandNameAttribute>()?.CommandName;

			if (name is null) continue;

			this._handlerTypes[name] = handlerType;
		}
	}

	public IHandler? GetHandler(string command)
	{
		var handlerType = this._handlerTypes.GetValueOrDefault(command);

		if (handlerType is null) return null;

		using var scope = this._serviceScopeFactory.CreateScope();

		return (IHandler) scope.ServiceProvider.GetRequiredService(handlerType);
	}
}