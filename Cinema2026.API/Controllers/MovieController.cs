using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Models;
using Cinema2026.Repo.Repositiories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema2026.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IGenericRepository<Movies> _repo;
        public MovieController(IGenericRepository<Movies> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public Task<Movies> CreatMovie([FromBody] Movies movies)
        {
            var created = _repo.Add(movies);
            return created;
        }

        [HttpGet("{MovieId}")]
        public Task<Movies?> GetMovieByid(int MovieId) => _repo.GetById(MovieId);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMoviesCatalog()
        {
            var moviesCatalog = await _repo.GetAll();
            return Ok(moviesCatalog);
        }



        [HttpDelete("{MovieId}")]
        public async Task<Movies> DeleteMovie(int MovieId)
        {
            var movie = await _repo.GetById(MovieId);
            if (movie == null)
                return null!;

            await _repo.Delete(MovieId);
            return null!;
        }
    }
}
