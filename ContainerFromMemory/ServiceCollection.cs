namespace ContainerFromMemory;

internal sealed class ServiceCollection : List<ServiceDescriptor>
{

	public ServiceCollection AddSingleton<TService, TImplementation>()
	{
		this.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
		return this;
	}
	public ServiceCollection AddTransient<TService, TImplementation>()
	{
		this.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
		return this;
	}


	public ServiceProvider BuildServiceProvider() => new ServiceProvider(this);

}