using RegularAPINET5.Models;
using System;
using System.Collections.Generic;

namespace RegularAPINET5.Repositories.Interfaces
{
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
}
