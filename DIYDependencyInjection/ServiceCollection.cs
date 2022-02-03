namespace DIYDependencyInjection;

internal sealed class ServiceCollection : List<ServiceDescriptor>
{
	public ServiceCollection AddSingleton<TService, TImplementation>()
	{
		Add(ServiceDescriptor.Create(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
		return this;
	}
	public ServiceCollection AddTransient<TService, TImplementation>()
	{
		Add(ServiceDescriptor.Create(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
		return this;
	}

	public ServiceProvider BuildServiceProvider() => new(this);


}