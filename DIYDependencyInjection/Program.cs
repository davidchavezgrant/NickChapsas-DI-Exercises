// See https://aka.ms/new-console-template for more information

using DIYDependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

services.AddSingleton<IConsoleWriter, ConsoleWriter>();

var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetService<IConsoleWriter>();

service.WriteLine("Hello from my DI");