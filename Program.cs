using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyFirstMCP;


// https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/
// https://www.youtube.com/watch?v=Coot4TFTkN4
var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
  // Configure all logs to go to stderr
  consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<MonkeyService>();

await builder.Build().RunAsync();
