using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")] // localhost:port/api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Person-repository'et, fordi det er her GetByUsername ligger
        private readonly IPersonRepositories _personRepo;

        public AuthController(IPersonRepositories personRepo)
        {
            _personRepo = personRepo;
        }

        // POST api/Auth/Register  -> opretter bruger og logger direkte ind
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Person person)
        {
            if (string.IsNullOrWhiteSpace(person.username) || string.IsNullOrWhiteSpace(person.password))
                return BadRequest("Brugernavn og password skal udfyldes");

            var findes = await _personRepo.GetByUsername(person.username);
            if (findes != null)
                return Conflict("Brugernavnet er allerede taget");

            person.PersonId = 0; // databasen laver selv id'et
            var created = await _personRepo.CreatePerson(person);

            await SignIn(created);
            return Ok(new { created.PersonId, created.username, created.email, created.age });
        }

        // POST api/Auth/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Person login)
        {
            var user = await _personRepo.GetByUsername(login.username);

            // NB: klartekst-sammenligning - bevidst valg i skoleprojektet
            if (user == null || user.password != login.password)
                return Unauthorized("Forkert brugernavn eller password");

            await SignIn(user);
            return Ok(new { user.PersonId, user.username, user.email, user.age });
        }

        // GET api/Auth/Me  -> hvem er logget ind? (401 hvis ingen)
        [Authorize]
        [HttpGet("Me")]
        public async Task<IActionResult> Me()
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var id))
                return Unauthorized();

            var user = await _personRepo.GetPersonById(id);
            if (user == null) return Unauthorized();

            return Ok(new { user.PersonId, user.username, user.email, user.age });
        }

        // POST api/Auth/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        // Fælles hjælpe-metode: laver login-cookien
        private async Task SignIn(Person user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.PersonId.ToString()),
                new Claim(ClaimTypes.Name, user.username)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
    }
}