namespace ContainerFromMemory;

internal sealed record ServiceDescriptor(Type ServiceType, Type ImplementationType, ServiceLifetime Lifetime);