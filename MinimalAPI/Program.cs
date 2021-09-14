using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PersonRepository>();

var app = builder.Build();

app.MapGet("/persons", (PersonRepository personRepository) =>
{
    return personRepository.GetAllPersons();
});

app.MapGet("/persons/{id}", (PersonRepository personRepository, Guid id) => {

    var person = personRepository.GetPersonById(id);

    if (person is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(person);
});

app.MapPost("/persons", (PersonRepository personRepository, Person person) => {
    personRepository.Create(person);

    return Results.Created($"/persons/{person.Id}", person);
});

app.MapPut("/persons/{id}", (PersonRepository personRepository, Guid id, Person updatedPerson) =>
{
    var person = personRepository.GetPersonById(id);

    if (person is null)
    {
        return Results.NotFound();
    }

    personRepository.Update(updatedPerson);

    return Results.NoContent();
});

app.MapDelete("/persons/{id}", (PersonRepository personRepository, Guid id) =>
{
    var person = personRepository.GetPersonById(id);

    if (person is null)
    {
        return Results.NotFound();
    }

    personRepository.Delete(id);

    return Results.Ok();
});

app.Run();

record Person(Guid Id, string Name, int Age);

class PersonRepository
{
    private readonly Dictionary<Guid, Person> _persons = new();

    public void Create(Person person)
    {
        if (person is null) return;

        _persons[person.Id] = person;
    }

    public Person? GetPersonById(Guid id)
    {
        return _persons.GetValueOrDefault(id);
    }

    public IReadOnlyCollection<Person> GetAllPersons()
    {
        return _persons.Values;
    }

    public void Update(Person person)
    {
        var existingEntry = GetPersonById(person.Id);

        if (existingEntry is null) return;

        _persons[person.Id] = person;
    }

    public void Delete(Guid id)
    {
        _persons.Remove(id);
    }

}