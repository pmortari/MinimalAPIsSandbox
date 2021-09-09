
using RegularAPINET6.Models;
using RegularAPINET6.Repositories.Interfaces;

namespace RegularAPINET6.Repositories;
public class PersonRepository : IPersonRepository
{
    private readonly Dictionary<Guid, Person> _persons = new();

    public void Create(Person person)
    {
        if (person is null) return;

        _persons[person.Id] = person;
    }

#nullable enable
    public Person? GetPersonById(Guid id)
    {
        return _persons.GetValueOrDefault(id);
    }
#nullable disable

    public List<Person> GetAllPersons()
    {
        return _persons.Values.ToList();
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

