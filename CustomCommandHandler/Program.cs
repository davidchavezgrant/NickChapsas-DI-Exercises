// See https://aka.ms/new-console-template for more information

using CustomCommandHandler;
using CustomCommandHandler.Console;
using CustomCommandHandler.Handlers;
using CustomCommandHandler.Time;
using CustomCommandHandler.Weather;
using FxResources.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();
services.AddSingleton<IConsoleWriter, ConsoleWriter>();
services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
services.AddSingleton<IWeatherService, OpenWeatherService>();
services.AddSingleton<HandlerOrchestrator>();
services.AddCommandHandlers(typeof(Program).Assembly);

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

await application.RunAsync(args);