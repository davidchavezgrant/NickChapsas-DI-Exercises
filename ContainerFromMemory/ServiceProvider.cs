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

	private void BuildServiceFromDescriptor(ServiceDescriptor descriptor)
	{
		switch (descriptor.Lifetime)
		{
			case ServiceLifetime.Singleton:
				CreateSingleton(descriptor);
				return;

			case ServiceLifetime.Transient:
				CreateTransient(descriptor);
				return;
		}
	}

	private void BuildServices(ServiceCollection serviceCollection)
	{
		foreach (ServiceDescriptor descriptor in serviceCollection) { BuildServiceFromDescriptor(descriptor); }
	}

	private object CreateInstance(ServiceDescriptor descriptor) =>
		Activator.CreateInstance(descriptor.ImplementationType, GetConstructorParameters(descriptor));

	private void CreateSingleton(ServiceDescriptor descriptor)
	{
		if (descriptor.Implementation is not null)
		{
			this._singletons[descriptor.ServiceType] = new Lazy<object>(descriptor.Implementation);
			return;
		}

		if (descriptor.ImplementationFactory is not null)
		{
			this._singletons[descriptor.ServiceType] = new Lazy<object>(() => descriptor.ImplementationFactory(this));
			return;
		}

		object instance = CreateInstance(descriptor);
		this._singletons[descriptor.ServiceType] = new Lazy<object>(instance);
	}

	private void CreateTransient(ServiceDescriptor descriptor)
	{
		if (descriptor.ImplementationFactory is not null)
		{
			this._transients[descriptor.ServiceType] = () => descriptor.ImplementationFactory(this);
			return;
		}

		this._transients[descriptor.ServiceType] = () => CreateInstance(descriptor);
	}

	private object?[] GetConstructorParameters(ServiceDescriptor descriptor)
	{
		ConstructorInfo constructor = descriptor.ImplementationType.GetConstructors()
												.First();

		var parameters = constructor.GetParameters();

		var dependencies = new List<object?>();

		foreach (ParameterInfo param in parameters) { dependencies.Add(GetService(param.ParameterType)); }

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

	public T? GetService<T>() => (T?)GetService(typeof(T));
}