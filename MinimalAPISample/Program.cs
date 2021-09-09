var app = WebApplication.CreateBuilder(args).Build();
app.MapGet("/", () => "Hello you lazy folks!");
app.Run();