using System.Reflection;

namespace DIYDependencyInjection;

internal sealed class ServiceProvider
{
	private readonly Dictionary<Type, Lazy<object>> _singletonTypes = new();
	private readonly Dictionary<Type, Func<object>> _transientTypes = new();

	internal ServiceProvider(ServiceCollection services)
	{
		GenerateServices(services);
	}

	private void GenerateServices(ServiceCollection services)
	{
		foreach (ServiceDescriptor serviceDescriptor in services)
		{
			switch (serviceDescriptor.Lifetime)
			{
				case ServiceLifetime.Singleton:
					this._singletonTypes[serviceDescriptor.ServiceType] =
						new Lazy<object>(Activator.CreateInstance(serviceDescriptor.ImplementationType,
																  GetConstructorParameters(serviceDescriptor))!);

					continue;

				case ServiceLifetime.Transient:
					this._transientTypes[serviceDescriptor.ServiceType] = () =>
						Activator.CreateInstance(serviceDescriptor.ImplementationType, GetConstructorParameters(serviceDescriptor))!;

					continue;
			}
		}
	}

	private object?[] GetConstructorParameters(ServiceDescriptor descriptor)
	{
		ConstructorInfo constructorInfo = descriptor.ImplementationType.GetConstructors()
													.First();

		object?[] parameters = constructorInfo.GetParameters()
											  .Select(x => GetService(x.ParameterType))
											  .ToArray();

		return parameters;
	}

	public T? GetService<T>() => (T?)GetService(typeof(T));

	public object? GetService(Type serviceType)
	{
		var service = this._singletonTypes.GetValueOrDefault(serviceType);

		if (service is not null) { return service.Value; }

		var transientService = this._transientTypes.GetValueOrDefault(serviceType);
		return transientService?.Invoke();
	}
}