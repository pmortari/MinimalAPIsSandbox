using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using System;

var httpFactory = HttpClientFactory.Create();

var minimalAPI = Step.Create("MinimalAPI", httpFactory, async context =>
{
    var response = await context.Client.GetAsync("http://localhost:5000/persons/6c032848-d04a-480f-9131-a4e7a0de0068");

    return response.IsSuccessStatusCode ?
    Response.Ok(statusCode: (int)response.StatusCode) :
    Response.Fail(statusCode: (int)response.StatusCode);
});

//var minimalAPITweaked = Step.Create("MinimalAPITweaked", httpFactory, async context =>
//{
//    var response = await context.Client.GetAsync("http://localhost:5001/persons/d1905fcc-412b-47d2-bd7c-30f70c9e4eea");

//    return response.IsSuccessStatusCode ?
//    Response.Ok(statusCode: (int)response.StatusCode) :
//    Response.Fail(statusCode: (int)response.StatusCode);
//});

var regularAPINET5 = Step.Create("RegularAPINET5", httpFactory, async context =>
{
    var response = await context.Client.GetAsync("http://localhost:5002/persons/758834a8-e99c-4c11-8862-3088ff051760");
    return response.IsSuccessStatusCode ?
    Response.Ok(statusCode: (int)response.StatusCode) :
    Response.Fail(statusCode: (int)response.StatusCode);
});

//var regularAPINET6 = Step.Create("RegularAPINET6", httpFactory, async context =>
//{
//    var response = await context.Client.GetAsync("http://localhost:5003/persons/6ab3afee-7f5b-4319-8e0e-266d594d972a");

//    return response.IsSuccessStatusCode ?
//    Response.Ok(statusCode: (int)response.StatusCode) :
//    Response.Fail(statusCode: (int)response.StatusCode);
//});

var minimalAPIScenario = ScenarioBuilder.CreateScenario("MinimalAPI", minimalAPI)
    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
    .WithLoadSimulations(Simulation.KeepConstant(20, TimeSpan.FromSeconds(60)));

//var minimalAPITweakedScenario = ScenarioBuilder.CreateScenario("MinimalAPITweaked", minimalAPITweaked)
//    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
//    .WithLoadSimulations(Simulation.KeepConstant(20, TimeSpan.FromSeconds(60)));

var regularAPINET5Scenario = ScenarioBuilder.CreateScenario("RegularAPINET5", regularAPINET5)
    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
    .WithLoadSimulations(Simulation.KeepConstant(20, TimeSpan.FromSeconds(60)));

//var regularAPINET6Scenario = ScenarioBuilder.CreateScenario("RegularAPINET6", regularAPINET6)
//    .WithWarmUpDuration(TimeSpan.FromSeconds(5))
//    .WithLoadSimulations(Simulation.KeepConstant(20, TimeSpan.FromSeconds(60)));

//NBomberRunner
//    .RegisterScenarios(minimalAPIScenario, minimalAPITweakedScenario, regularAPINET5Scenario, regularAPINET6Scenario)
//    .Run();

NBomberRunner
    .RegisterScenarios(minimalAPIScenario, regularAPINET5Scenario)
    .Run();