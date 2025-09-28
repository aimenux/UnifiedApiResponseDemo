using Presentation;
using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup();
startup.ConfigureServices(builder);
var app = builder.Build();
await app.InitializeDatabaseAsync();
startup.Configure(app);
await app.RunAsync();