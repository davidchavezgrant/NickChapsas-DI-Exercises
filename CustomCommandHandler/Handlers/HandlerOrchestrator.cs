using System.Reflection;
using FxResources.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CustomCommandHandler.Handlers;

public sealed class HandlerOrchestrator
{
	private readonly Dictionary<string, Type> _handlerTypes = new();
	private readonly IServiceScopeFactory     _serviceScopeFactory;
	public HandlerOrchestrator(IServiceScopeFactory serviceScopeFactory)
	{
		this._serviceScopeFactory = serviceScopeFactory;
		RegisterCommandHandlers();
	}

	private void RegisterCommandHandlers()
	{
		var handlerTypes = HandlerExtensions.GetHandlerTypesForAssembly(typeof(IHandler).Assembly);
		foreach (var handlerType in handlerTypes)
		{
			var commandNameAttribute = handlerType.GetCustomAttribute<CommandNameAttribute>();
			if (commandNameAttribute is null) continue;

			var commandName = commandNameAttribute.CommandName;
			this._handlerTypes[commandName] = handlerType;
		}
	}

	public IHandler? GetHandlerForCommandName(string command)
	{
		var handlerType = this._handlerTypes.GetValueOrDefault(command);

		if (handlerType is null)
		{
			return null;
		}

		using var serviceScope = this._serviceScopeFactory.CreateScope();

		return (IHandler) serviceScope.ServiceProvider.GetRequiredService(handlerType);
	}
}