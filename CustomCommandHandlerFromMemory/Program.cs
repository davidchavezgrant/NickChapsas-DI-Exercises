// See https://aka.ms/new-console-template for more information
using CustomCommandHandlerFromMemory;
using CustomCommandHandlerFromMemory.Console;
using CustomCommandHandlerFromMemory.Time;
using CustomCommandHandlerFromMemory.Weather;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddSingleton<IConsoleWriter, ConsoleWriter>();
services.AddSingleton<IWeatherService, WeatherService>();
services.AddSingleton<ITimeService, TimeService>();
services.AddCommandHandlers(typeof(Program).Assembly);
services.AddSingleton<Application>();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<Application>();

 app.Run(args);