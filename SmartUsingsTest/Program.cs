// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartUsingsTest;

var services = new ServiceCollection();

services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
services.AddSingleton(typeof(IConsoleWriter<>), typeof(ConsoleWriter<>));
services.AddTransient<WeatherService>();
services.AddTransient<IWeatherService>(provider => new LoggedWeatherService(provider.GetService<WeatherService>(), provider.GetService<ILoggerAdapter<IWeatherService>>()));

var provider = services.BuildServiceProvider();

var weatherService = provider.GetService<IWeatherService>();

var weather = weatherService.GetCurrentWeather("Boston");

Console.WriteLine(weather);