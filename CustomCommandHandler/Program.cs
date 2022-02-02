// See https://aka.ms/new-console-template for more information

using CustomCommandHandler;
using CustomCommandHandler.Console;
using CustomCommandHandler.Time;
using CustomCommandHandler.Weather;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();
services.AddSingleton<IConsoleWriter, ConsoleWriter>();
services.AddHttpClient();
services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
services.AddSingleton<IWeatherService, OpenWeatherService>();

services.AddSingleton<Application>();

var serviceProvider = services.BuildServiceProvider();

var application = serviceProvider.GetRequiredService<Application>();

if (args.Length == 0)
{
	args = new[]
	{
		"weather"
	};
}

await application.RunAsync();