namespace ContainerFromMemory;

internal sealed class ServiceCollection : List<ServiceDescriptor>
{
	public ServiceCollection AddSingleton<TService, TImplementation>()
	where TService : class
	where TImplementation : class, TService
	{
		Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
		return this;
	}

	public ServiceCollection AddTransient<TService, TImplementation>()
	where TService : class
	where TImplementation : class, TService
	{
		Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
		return this;
	}

	public ServiceProvider BuildServiceProvider() => new(this);
}