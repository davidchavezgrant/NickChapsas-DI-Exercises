using Jab;

namespace SourceGeneratorTEst;

[ServiceProvider]
[Transient(typeof(IConsoleWriter), typeof(ConsoleWriter))]
public partial class MyServiceProvider
{

}