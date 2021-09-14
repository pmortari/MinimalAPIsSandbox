using MinimalAPITweaked.Models;
using MinimalAPITweaked.Extensions;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServicesDefinitions(typeof(Person));

var app = builder.Build();
app.UseEndpointDefinitions();

app.Run();

