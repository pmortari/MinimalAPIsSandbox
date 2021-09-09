
using RegularAPINET6.Models;

namespace RegularAPINET6.Repositories.Interfaces;
public interface IPersonRepository
{
    void Create(Person person);
#nullable enable
    Person? GetPersonById(Guid id);
#nullable disable
    List<Person> GetAllPersons();
    void Update(Person person);
    void Delete(Guid id);
}
