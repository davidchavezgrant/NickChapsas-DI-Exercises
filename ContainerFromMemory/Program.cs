// See https://aka.ms/new-console-template for more information

using ContainerFromMemory;


var services = new ServiceCollection();

services.AddTransient<IConsoleWriter, ConsoleWriter>();

var provider = services.BuildServiceProvider();

var console = provider.GetService<IConsoleWriter>();

console.WriteLine("Hello from custom DI!");