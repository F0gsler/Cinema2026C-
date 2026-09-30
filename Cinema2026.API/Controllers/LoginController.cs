using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IPersonRepositories _personRepo;

        public LoginController(IPersonRepositories personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Person person)
        {
            if (string.IsNullOrWhiteSpace(person.username) || string.IsNullOrWhiteSpace(person.password))
                return BadRequest("Brugernavn og password skal udfyldes");

            var findes = await _personRepo.GetByUsername(person.username);
            if (findes != null)
                return Conflict("Brugernavnet er allerede taget");

            person.PersonId = 0;
            var created = await _personRepo.CreatePerson(person);

            return Ok(new { created.PersonId, created.username, created.email, created.age });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Person login)
        {
            var user = await _personRepo.GetByUsername(login.username);

            if (user == null || user.password != login.password)
                return Unauthorized("Forkert brugernavn eller password");

            return Ok(new { user.PersonId, user.username, user.email, user.age });
        }
    }
}