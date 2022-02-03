namespace ContainerFromMemory;

internal sealed class ServiceCollection : List<ServiceDescriptor>
{
	public ServiceCollection AddService(ServiceDescriptor serviceDescriptor)
	{
		Add(serviceDescriptor);
		return this;
	}

	public ServiceCollection AddSingleton<TService>()
	where TService : class
	{
		Add(new ServiceDescriptor(typeof(TService),
								  typeof(TService),
								  ServiceLifetime.Singleton,
								  null,
								  null));

		return this;
	}

	public ServiceCollection AddSingleton<TService>(Func<ServiceProvider, TService> factory)
	where TService : class
	{
		Add(new ServiceDescriptor(typeof(TService),
								  typeof(TService),
								  ServiceLifetime.Singleton,
								  null,
								  factory));

		return this;
	}

	public ServiceCollection AddSingleton(object implementation)
	{
		Type serviceType = implementation.GetType();

		Add(new ServiceDescriptor(serviceType,
								  serviceType,
								  ServiceLifetime.Singleton,
								  implementation,
								  null));

		return this;
	}

	public ServiceCollection AddSingleton<TService, TImplementation>()
	where TService : class
	where TImplementation : class, TService
	{
		Add(new ServiceDescriptor(typeof(TService),
								  typeof(TImplementation),
								  ServiceLifetime.Singleton,
								  null,
								  null));

		return this;
	}

	public ServiceCollection AddTransient<TService>(Func<ServiceProvider, TService> factory)
	where TService : class
	{
		Add(new ServiceDescriptor(typeof(TService),
								  typeof(TService),
								  ServiceLifetime.Transient,
								  null,
								  factory));

		return this;
	}

	public ServiceCollection AddTransient<TService>()
	where TService : class
	{
		Add(new ServiceDescriptor(typeof(TService),
								  typeof(TService),
								  ServiceLifetime.Transient,
								  null,
								  null));

		return this;
	}

	public ServiceCollection AddTransient<TService, TImplementation>()
	where TService : class
	where TImplementation : class, TService
	{
		Add(new ServiceDescriptor(typeof(TService),
								  typeof(TImplementation),
								  ServiceLifetime.Transient,
								  null,
								  null));

		return this;
	}

	public ServiceProvider BuildServiceProvider() => new(this);
}