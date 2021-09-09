using MinimalAPITweaked.Models;
using MinimalAPITweaked.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServicesDefinitions(typeof(Person));

var app = builder.Build();
app.UseEndpointDefinitions();

app.Run();

