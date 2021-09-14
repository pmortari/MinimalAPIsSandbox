using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MinimalAPITweaked.EndpointDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimalAPITweaked.Extensions;
public static class EndpointDefinitionExtension
{
    public static void AddServicesDefinitions(this IServiceCollection services, params Type[] scanMarkers)
    {
        var endpointDefinitions = new List<IEndpointDefinition>();

        foreach (var scanMarker in scanMarkers)
        {
            endpointDefinitions.AddRange(scanMarker.Assembly.ExportedTypes
                .Where(p => typeof(IEndpointDefinition).IsAssignableFrom(p) && 
                            p.IsInterface == false &&
                            p.IsAbstract == false)
                .Select(Activator.CreateInstance).Cast<IEndpointDefinition>());
        }

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineServices(services);
        }

        services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
    }

    public static void UseEndpointDefinitions(this WebApplication app)
    {
        var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (var definition in definitions)
        {
            definition.DefineEndpoints(app);
        }
    }

}
