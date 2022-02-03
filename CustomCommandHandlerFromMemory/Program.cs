// See https://aka.ms/new-console-template for more information
using CustomCommandHandlerFromMemory;
using CustomCommandHandlerFromMemory.Console;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddSingleton<IConsoleWriter, ConsoleWriter>();
services.AddCommandHandlers(typeof(Program).Assembly);
services.AddSingleton<Application>();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<Application>();

 app.Run(args);