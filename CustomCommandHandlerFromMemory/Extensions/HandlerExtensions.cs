using System.Reflection;
using CustomCommandHandlerFromMemory;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class HandlerExtensions
{
	public static void AddCommandHandlers(this IServiceCollection services, Assembly assembly)
	{
		services.TryAddSingleton<Mediator>();

		var handlerTypes = GetHandlerTypesForAssembly(assembly);

		foreach (TypeInfo handlerType in handlerTypes)
		{
			services.TryAddTransient(handlerType);
		}
	}

	public static IEnumerable<TypeInfo> GetHandlerTypesForAssembly(Assembly assembly)
	{
		return assembly.DefinedTypes.Where(x => !x.IsAbstract && !x.IsInterface && x.IsAssignableTo(typeof(IHandler)));
	}
}