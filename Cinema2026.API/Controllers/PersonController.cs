using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Repositiories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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

        [HttpGet]
        public async Task<List<Person>> GetPersonAsync()
        {
            return await personRepo.GetPersonAsync();
        }

        [HttpPost]
        public async Task<Person> Post([FromBody] Person person)
        {
            var created = await personRepo.CreatePerson(person);
            return created;
        }
    }
}
