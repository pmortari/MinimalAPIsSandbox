using MinimalAPITweaked.Models;

namespace MinimalAPITweaked.Repositories;

public interface IPersonRepository
{
    void Create(Person person);
#nullable enable
    Person? GetPersonById(Guid id);
#nullable disable
    IReadOnlyCollection<Person> GetAllPersons();
    void Update(Person person);
    void Delete(Guid id);
}

public class PersonRepository : IPersonRepository
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