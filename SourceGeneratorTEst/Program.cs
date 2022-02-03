// See https://aka.ms/new-console-template for more information

using SourceGeneratorTEst;



var serviceProvider = new MyServiceProvider();

var consoleWriter = serviceProvider.GetService<IConsoleWriter>();

consoleWriter.WriteLine("Hello world!");