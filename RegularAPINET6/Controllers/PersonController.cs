using Microsoft.AspNetCore.Mvc;
using RegularAPINET6.Models;
using RegularAPINET6.Repositories.Interfaces;

namespace RegularAPINET6.Controllers;
[ApiController]
[Route("persons")]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_personRepository.GetAllPersons());
    }

    [HttpGet("{id}")]
    public IActionResult GetPersonById(Guid id)
    {
        var person = _personRepository.GetPersonById(id);

        if (person is null)
        {
            return NotFound(null);
        }

        return Ok(person);
    }

    [HttpPost]
    public IActionResult CreatePerson(Person person)
    {
        _personRepository.Create(person);

        return Created("", person);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePerson(Guid id, Person updatedPerson)
    {
        var person = _personRepository.GetPersonById(id);

        if (person == null)
        {
            return NotFound(null);
        }

        _personRepository.Update(updatedPerson);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(Guid id)
    {
        var person = _personRepository.GetPersonById(id);

        if (person == null)
        {
            return NotFound(null);
        }

        _personRepository.Delete(id);

        return Ok();
    }
}
