using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.NativeInterop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")] // localhost:port/api/person
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/<PersonController>

        IPersonRepositories personRepo;

        public PersonController(IPersonRepositories r)
        {
            personRepo = r;
        }

        [HttpGet("GetAllPeople")]
        public async Task<List<Person>> GetAllPeople()
        {
            return await personRepo.GetAllPeople();
        }

        [HttpPost("CreatePerson")]
        public async Task<Person> Post([FromBody] Person person)
        {
            var created = await personRepo.CreatePerson(person);
            return created;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await personRepo.GetPersonById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<Person> Put(int id, [FromBody] Person person)
        {
            if (person == null || person.PersonId != id) return null!;
            await personRepo.UpdatePerson(person);
            return null!;
        }

        [HttpDelete("{id}")]
        public async Task<Person> Delete(int id)
        {
            await personRepo.DeletePerson(id);
            return null!;
        }


    }
}
