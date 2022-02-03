using System.Reflection;

namespace ContainerFromMemory;

internal sealed class ServiceProvider
{
	private readonly Dictionary<Type, Lazy<object>> _singletons = new();
	private readonly Dictionary<Type, Func<object>> _transients = new();

	public ServiceProvider(ServiceCollection services)
	{
		BuildServices(services);
	}

	private void BuildServices(ServiceCollection serviceCollection)
	{
		foreach (ServiceDescriptor descriptor in serviceCollection)
		{
			switch (descriptor.Lifetime)
			{
				case ServiceLifetime.Singleton:
					object instance = CreateInstance(descriptor);
					this._singletons[descriptor.ServiceType] = new Lazy<object>(instance);

					continue;

				case ServiceLifetime.Transient:
					this._transients[descriptor.ServiceType] = () => CreateInstance(descriptor);
					continue;
			}
		}
	}

	private object CreateInstance(ServiceDescriptor descriptor) =>
		Activator.CreateInstance(descriptor.ImplementationType, GetConstructorParameters(descriptor));

	private object?[] GetConstructorParameters(ServiceDescriptor descriptor)
	{
		ConstructorInfo constructor = descriptor.ImplementationType.GetConstructors()
												.First();

		var parameters = constructor.GetParameters();

		var dependencies = new List<object?>();

		foreach (var param in parameters)
		{
			dependencies.Add(GetService(param.ParameterType));
		}

		return dependencies.ToArray();
	}

	public object? GetService(Type type)
	{
		var singleton = this._singletons.GetValueOrDefault(type);

		if (singleton is not null) return singleton.Value;

		var transient = this._transients.GetValueOrDefault(type);

		if (transient is not null) return transient.Invoke();

		return null;
	}

	public T? GetService<T>() => (T?) GetService(typeof(T));

}