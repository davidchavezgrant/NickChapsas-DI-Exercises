using System.Reflection;
using CustomCommandHandler.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FxResources.Microsoft.Extensions.DependencyInjection;
public static class HandlerExtensions
{
	public static void AddCommandHandlers (this IServiceCollection services, Assembly assembly)
	{
		services.TryAddSingleton<HandlerOrchestrator>();

		var handlerTypes = GetHandlerTypesForAssembly(assembly);

		foreach (var handlerType in handlerTypes)
		{
			services.TryAddTransient(handlerType);
		}
	}

	public static IEnumerable<TypeInfo> GetHandlerTypesForAssembly(Assembly assembly)
	{
		return assembly.DefinedTypes.Where(x => !x.IsInterface && !x.IsAbstract && typeof(IHandler).IsAssignableFrom(x));
	}
}