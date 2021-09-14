using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MinimalAPITweaked.Models;
using MinimalAPITweaked.Repositories;
using System;
using System.Collections.Generic;

namespace MinimalAPITweaked.EndpointDefinitions;
public class PersonEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/persons", GetAllPersons);
        app.MapGet("/persons/{id}", GetPersonById);
        app.MapPost("/persons", CreatePerson);
        app.MapPut("/persons/{id}", UpdatePerson);
        app.MapDelete("/persons/{id}", DeletePerson);
    }    

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<IPersonRepository, PersonRepository>();
    }

    internal IResult GetPersonById(IPersonRepository personRepository, Guid id)
    {
        var person = personRepository.GetPersonById(id);

        if (person is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(person);
    }

    internal IReadOnlyCollection<Person> GetAllPersons(IPersonRepository personRepository)
    {
        return personRepository.GetAllPersons();
    }

    internal IResult CreatePerson(IPersonRepository personRepository, Person person)
    {
        personRepository.Create(person);

        return Results.Created($"/persons/{person.Id}", person);
    }

    internal IResult UpdatePerson(IPersonRepository personRepository, Guid id, Person updatedPerson)
    {
        var person = personRepository.GetPersonById(id);

        if (person is null)
        {
            return Results.NotFound();
        }

        personRepository.Update(updatedPerson);

        return Results.NoContent();
    }

    internal IResult DeletePerson(IPersonRepository personRepository, Guid id)
    {
        var person = personRepository.GetPersonById(id);

        if (person is null)
        {
            return Results.NotFound();
        }

        personRepository.Delete(id);

        return Results.Ok();
    }
}
