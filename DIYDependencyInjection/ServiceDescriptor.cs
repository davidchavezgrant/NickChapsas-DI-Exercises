namespace DIYDependencyInjection;

internal sealed class ServiceDescriptor
{
	public Type            ServiceType        { get; init; } = default!;
	public Type          ImplementationType { get; set; }
	public ServiceLifetime Lifetime           { get; set; }

	internal static ServiceDescriptor Create(Type service, Type? implementation, ServiceLifetime lifetime)
	{
		return new ServiceDescriptor
		{
			ServiceType        = service,
			ImplementationType = implementation,
			Lifetime           = lifetime
		};
	}
}